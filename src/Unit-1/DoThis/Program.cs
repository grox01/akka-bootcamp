using System;
﻿using Akka.Actor;

namespace WinTail
{
    #region Program
    class Program
    {
        public static ActorSystem MyActorSystem;

        static void Main(string[] args)
        {
            // initialize MyActorSystem
            // YOU NEED TO FILL IN HERE
            MyActorSystem = ActorSystem.Create("MyActorSystem");

            //PrintInstructions();

            // time to make your first actors!
            //YOU NEED TO FILL IN HERE

            // make tailCoordinatorActor
            Props tailCoordinatorProps = Props.Create(() => new TailCoordinatorActor());
            IActorRef tailCoordinatorActor = MyActorSystem.ActorOf(tailCoordinatorProps,
                "tailCoordinatorActor");

            // make consoleWriterActor using these props: Props.Create(() => new ConsoleWriterActor())
            // make consoleReaderActor using these props: Props.Create(() => new ConsoleReaderActor(consoleWriterActor))
            var consoleWriterActor = MyActorSystem.ActorOf(Props.Create(() => new ConsoleWriterActor()));
            //var validationActor = MyActorSystem.ActorOf(Props.Create(() => new ValidationActor(consoleWriteActor)));

            // pass tailCoordinatorActor to fileValidatorActorProps (just adding one extra arg)
            Props fileValidatorActorProps = Props.Create(() =>
            new FileValidatorActor(consoleWriterActor));
            IActorRef validationActor = MyActorSystem.ActorOf(fileValidatorActorProps,
                "validationActor");

            var consoleReaderActor = MyActorSystem.ActorOf(Props.Create<ConsoleReaderActor>());

            // tell console reader to begin
            //YOU NEED TO FILL IN HERE
            consoleReaderActor.Tell(ConsoleReaderActor.StartCommand);

            // blocks the main thread from exiting until the actor system is shut down
            MyActorSystem.WhenTerminated.Wait();
        }

        //private static void PrintInstructions()
        //{
        //    Console.WriteLine("Write whatever you want into the console!");
        //    Console.Write("Some lines will appear as");
        //    Console.ForegroundColor = ConsoleColor.DarkRed;
        //    Console.Write(" red ");
        //    Console.ResetColor();
        //    Console.Write(" and others will appear as");
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.Write(" green! ");
        //    Console.ResetColor();
        //    Console.WriteLine();
        //    Console.WriteLine();
        //    Console.WriteLine("Type 'exit' to quit this application at any time.\n");
        //}
    }
    #endregion
}
