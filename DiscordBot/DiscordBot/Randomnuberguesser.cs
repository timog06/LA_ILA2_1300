namespace DiscordBot
{
    class Randomnuberguesser
    {
        public static void MainGame()
        {
            int num = NumberGeneration();
            
            
        }
        static int NumberGeneration()
        {
            Random rnd = new();
            return rnd.Next(1, 101);
        }
    }

}
