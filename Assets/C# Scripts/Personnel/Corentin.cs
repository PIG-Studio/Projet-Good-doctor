using System;
using Super.Interfaces;

namespace Personnel
{
    public class Corentin : PNJ.Immobile.Personnel , ISpawn
    {
        public Corentin()
        {
            //Skin = Skin de Corentin
            // First Name = Corentin
            // Surname = Pas de nom
            // Position = Dans le labo
        }
        
        
        /// <summary>
        /// Fonction qui Renvoie Depression et Adn du patient dans le bureau
        /// </summary>
        public void AnalysePatient()
        {
            //Si InDesk.Patient.AnalyseAdn == False alors AnalasyeAdn = True , rajoute à la fiche et renvoie son ADN
            //SI InDesk.Patient.AnalyseDepression == False  alors AnalyseDepression = True , rajoute à la fiche et renvoie sa Depression
        }
        
        /// <summary>
        /// Fonction qui renvoie une phrase
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Talk()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// spawn Corentin au debut de la partie dans le labo
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Spawn()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode pour désinstancier Corentin
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Despawn()
        {
            throw new NotImplementedException();
        }
    }
}