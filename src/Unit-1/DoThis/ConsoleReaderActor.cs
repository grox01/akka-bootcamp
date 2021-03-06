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
        public const string StartCommand = "start";
        public const string ReadCommand = "read";
        public const string ContinueCommnad = "continue";
        //private IActorRef _consoleWriterActor;

        public ConsoleReaderActor()
        {
            //_consoleWriterActor = consoleWriterActor;
        }

        protected override void OnReceive(object message)
        {
            if (StartCommand.Equals(message))
            {
                DoPrintInstructions();
            }
            GetAndValidateInput();
            return;



            //else if (message is Messages.InputError) {
            //    _consoleWriterActor.Tell(message as Messages.InputError);
            //}

            //GetAndValidateInput();
            //return;

            //var read = Console.ReadLine();
            //if (!string.IsNullOrEmpty(read) && String.Equals(read, ExitCommand, StringComparison.OrdinalIgnoreCase))
            //{
            //    // shut down the system (acquire handle to system via
            //    // this actors context)
            //    Context.System.Terminate();
            //    return;
            //}

            // send input to the console writer to process and print
            // YOU NEED TO FILL IN HERE
            //if (String.Equals(message, ReadCommand, StringComparison.OrdinalIgnoreCase)) {
                //_consoleWriterActor.Tell(read);
                //Self.Tell("continue");
            //}

            //// continue reading messages from the console
            //// YOU NEED TO FILL IN HERE
            //if (string.Equals(message, ContinueCommnad, StringComparison.OrdinalIgnoreCase)
            //{
            //    _consoleWriterActor.Tell(read);
            //    Self.Tell("continue");
            //}


        }

        private void GetAndValidateInput()
        {
            var message = Console.ReadLine();

            if (!string.IsNullOrEmpty(message) && String.Equals(message, ExitCommand, StringComparison.OrdinalIgnoreCase))
            {
                // shut down the system (acquire handle to system via
                // this actors context)
                Context.System.Terminate();
                return;
            }

            Context.ActorSelection("akka://MyActorSystem/user/validationActor").Tell(message);
            //_consoleWriterActor.Tell(message);



            //if (string.IsNullOrEmpty(message))
            //{
            //    // signal that the user needs to supply an input, as previously
            //    // received input was blank
            //    Self.Tell(new Messages.NullInputError("No input received."));
            //}
            //else if (String.Equals(message, ExitCommand, StringComparison.OrdinalIgnoreCase))
            //{
            //    // shut down the entire actor system (allows the process to exit)
            //    Context.System.Terminate();
            //}
            //else
            //{
            //    var valid = IsValid(message);
            //    if (valid)
            //    {
            //        _consoleWriterActor.Tell(new Messages.InputSuccess("Thank you! Message was valid."));

            //// continue reading messages from console
            //        Self.Tell(new Messages.ContinueProcessing());
            //    }
            //    else
            //    {
            //        Self.Tell(new Messages.ValidationError("Invalid: input had odd number of characters."));
            //    }
            //}
        }

        //private static bool IsValid(string message)
        //{
        //    var valid = message.Length % 2 == 0;
        //    return valid;
        //}

        private void DoPrintInstructions()
        {
            Console.WriteLine("Please provide the URI of a log file on disk.\n");
            return;

            Console.WriteLine("Write whatever you want into the console!");
            Console.WriteLine("Some entries will pass validation, and some won't...\n\n");
            Console.WriteLine("Type 'exit' to quit this application at any time.\n");
        }
    }
}