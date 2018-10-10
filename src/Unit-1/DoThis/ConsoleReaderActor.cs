using System;
using Akka.Actor;

namespace WinTail
{
    /// <summary>
    /// Actor responsible for reading FROM the console. 
    /// Also responsible for calling <see cref="ActorSystem.Terminate"/>.
    /// </summary>
    class ConsoleReaderActor : UntypedActor
    {
        public const string ExitCommand = "exit";
        //public const string ReadCommand = "read";
        //public const string ContinueCommnad = "continue";
        private IActorRef _consoleWriterActor;

        public ConsoleReaderActor(IActorRef consoleWriterActor)
        {
            _consoleWriterActor = consoleWriterActor;
        }

        protected override void OnReceive(object message)
        {
            var read = Console.ReadLine();
            if (!string.IsNullOrEmpty(read) && String.Equals(read, ExitCommand, StringComparison.OrdinalIgnoreCase))
            {
                // shut down the system (acquire handle to system via
                // this actors context)
                Context.System.Terminate();
                return;
            }

            // send input to the console writer to process and print
            // YOU NEED TO FILL IN HERE
            //if (String.Equals(message, ReadCommand, StringComparison.OrdinalIgnoreCase)) {
                _consoleWriterActor.Tell(read);
                Self.Tell("continue");
            //}

            //// continue reading messages from the console
            //// YOU NEED TO FILL IN HERE
            //if (string.Equals(message, ContinueCommnad, StringComparison.OrdinalIgnoreCase)
            //{
            //    _consoleWriterActor.Tell(read);
            //    Self.Tell("continue");
            //}


        }

    }
}