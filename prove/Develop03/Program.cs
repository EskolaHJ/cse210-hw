using System;
using System.Collections.Generic;

namespace ScriptureMemory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select a scripture volume:");
            Console.WriteLine("1. Bible");
            Console.WriteLine("2. Book of Mormon");
            Console.WriteLine("3. Doctrine and Covenants");
            int volumeChoice = Convert.ToInt32(Console.ReadLine());

            Dictionary<int, Scripture> scriptures = new Dictionary<int, Scripture>();

            switch (volumeChoice)
            {
                case 1:  // Bible
                    scriptures[1] = new Scripture(new ScriptureReference(ScriptureVolume.Bible, "John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
                    scriptures[2] = new Scripture(new ScriptureReference(ScriptureVolume.Bible, "Psalms", 23, 1), "The LORD is my shepherd; I shall not want.");
                    scriptures[3] = new Scripture(new ScriptureReference(ScriptureVolume.Bible, "Proverbs", 3, 5), "Trust in the LORD with all your heart and lean not on your own understanding.");
                    scriptures[4] = new Scripture(new ScriptureReference(ScriptureVolume.Bible, "Matthew", 5, 6), "Blessed are those who hunger and thirst for righteousness, for they will be filled.");
                    scriptures[5] = new Scripture(new ScriptureReference(ScriptureVolume.Bible, "Romans", 8, 28), "And we know that in all things God works for the good of those who love him, who have been called according to his purpose.");
                    break;

                case 2:  // Book of Mormon
                    scriptures[1] = new Scripture(new ScriptureReference(ScriptureVolume.BookOfMormon, "1 Nephi", 3, 7), "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.");
                    scriptures[2] = new Scripture(new ScriptureReference(ScriptureVolume.BookOfMormon, "2 Nephi", 2, 25), "Adam fell that men might be; and men are, that they might have joy.");
                    scriptures[3] = new Scripture(new ScriptureReference(ScriptureVolume.BookOfMormon, "Alma", 7, 11), "And he shall go forth, suffering pains and afflictions and temptations of every kind; and this that the word might be fulfilled which saith he will take upon him the pains and the sicknesses of his people.");
                    scriptures[4] = new Scripture(new ScriptureReference(ScriptureVolume.BookOfMormon, "Moroni", 10, 4), "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost.");
                    scriptures[5] = new Scripture(new ScriptureReference(ScriptureVolume.BookOfMormon, "Ether", 12, 6), "And now, I, Moroni, would speak somewhat concerning these things; I would show unto the world that faith is things which are hoped for and not seen; wherefore, dispute not because ye see not, for ye receive no witness until after the trial of your faith.");
                    break;

                case 3:  // Doctrine and Covenants
                    scriptures[1] = new Scripture(new ScriptureReference(ScriptureVolume.DoctrineAndCovenants, "Section", 4, 2), "Therefore, O ye that embark in the service of God, see that ye serve him with all your heart, might, mind and strength, that ye may stand blameless before God at the last day.");
                    scriptures[2] = new Scripture(new ScriptureReference(ScriptureVolume.DoctrineAndCovenants, "Section", 58, 27), "Verily I say, men should be anxiously engaged in a good cause, and do many things of their own free will, and bring to pass much righteousness;");
                    scriptures[3] = new Scripture(new ScriptureReference(ScriptureVolume.DoctrineAndCovenants, "Section", 130, 22), "The Father has a body of flesh and bones as tangible as man’s; the Son also; but the Holy Ghost has not a body of flesh and bones, but is a personage of Spirit. Were it not so, the Holy Ghost could not dwell in us.");
                    scriptures[4] = new Scripture(new ScriptureReference(ScriptureVolume.DoctrineAndCovenants, "Section", 89, 20), "And all saints who remember to keep and do these sayings, walking in obedience to the commandments, shall receive health in their navel and marrow to their bones;");
                    scriptures[5] = new Scripture(new ScriptureReference(ScriptureVolume.DoctrineAndCovenants, "Section", 138, 3), "I saw the hosts of the dead, both small and great, and there were gathered together in one place an innumerable company of the spirits of the just, who had been faithful in the testimony of Jesus while they lived in mortality;");
                    break;
            }

            Console.Clear();
            Console.WriteLine("Select a scripture:");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"{i}. {scriptures[i].ToString().Split('\n')[0]}..."); // Displaying only the reference part for clarity.
            }
            int scriptureChoice = Convert.ToInt32(Console.ReadLine());

            Scripture selectedScripture = scriptures[scriptureChoice];

            while (!selectedScripture.AllWordsHidden)
            {
                Console.Clear();
                Console.WriteLine(selectedScripture);
                Console.WriteLine("\nPress ENTER to hide a word or type 'quit' to exit.");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "quit") break;

                selectedScripture.HideRandomWord();
            }
        }
    }
}
