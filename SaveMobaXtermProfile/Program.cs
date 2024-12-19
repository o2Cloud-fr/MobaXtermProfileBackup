using System;
using System.IO;
using System.IO.Compression;

namespace SaveMobaXtermProfile
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Étape 1 : Définir le chemin du profil MobaXterm
                string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string mobaxtermProfilePath = Path.Combine(userProfile, "AppData", "Roaming", "MobaXterm");

                // Vérification si le dossier existe
                if (!Directory.Exists(mobaxtermProfilePath))
                {
                    Console.WriteLine("Le dossier de profil MobaXterm n'existe pas à l'emplacement attendu.");
                    return;
                }

                Console.WriteLine("Profil MobaXterm détecté : " + mobaxtermProfilePath);

                // Étape 2 : Demander à l'utilisateur le nom du fichier ZIP
                Console.Write("Entrez le nom du fichier ZIP (sans extension) : ");
                string zipFileName = Console.ReadLine();

                // Étape 3 : Créer le chemin du fichier ZIP sur le bureau
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string zipFilePath = Path.Combine(desktopPath, $"{zipFileName}.zip");

                // Étape 4 : Créer l'archive ZIP
                if (File.Exists(zipFilePath))
                {
                    Console.WriteLine("Un fichier ZIP avec ce nom existe déjà. Suppression de l'ancien fichier...");
                    File.Delete(zipFilePath);
                }

                Console.WriteLine("Compression du profil en cours...");
                ZipFile.CreateFromDirectory(mobaxtermProfilePath, zipFilePath);

                Console.WriteLine($"Profil MobaXterm sauvegardé avec succès dans : {zipFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur s'est produite : " + ex.Message);
            }
        }
    }
}
