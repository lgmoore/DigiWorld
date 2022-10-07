namespace DigiWorld
{
    public abstract class Command
    {
        protected Command()
        {
        }

        /// <summary>
        /// Abstract method to execute a Command.
        /// </summary>
        /// <returns>
        /// string: The resolution of the excecuted command.
        /// </returns>
        /// <param name="text">
        /// The <see cref="Player"/> input as an array.
        /// </param>
        public abstract string Execute(string[] text);
    }
}