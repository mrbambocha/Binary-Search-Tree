using System.Collections.Generic;

namespace Labb4
{
    ///<summary>
    ///Enum för att hålla ordning på vilken ordning det binära trädet
    ///ska skriva ut trädet.
    ///</summary>
    public enum SortOrder 
    {
        Pre,
        Post,
        In
    }
    public interface ITree
    {
        /// <summary>
        /// Antal noder i trädet.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Lägger till en nod i trädet, om nyckeln redan finns
        /// ökar vi på value på noden istället för att lägga till en ny 
        /// nod.
        /// </summary>
        /// <param name="key">Den söknyckel som hör till värdet</param>
        /// <param name="value">Det värde som ska sparas i trädet</param>
        void Add(string key, int value);

        /// <summary>
        /// Returnerar trädets höjd.
        /// </summary>
        /// <returns>Trädets höjd</returns>        
        int Height();

        /// <summary>
        /// Returnerar true eller false beroende på om trädet
        /// innehåller en nod vars nyckel överenstämmer med key.
        /// </summary>
        /// <param name="key">key är nyckeln till den sökta noden</param>
        /// <returns>true om noden finns, i annat fall false</returns> 
        bool Contains(string key);
 
        /// <summary>
        /// Tar bort noden vars söknyckel överensstämmer
        /// med key.
        /// </summary>
        /// <param name="key">Nyckel till den nod som ska tas bort</param>
        void Remove(string key);
 
        /// <summary>
        /// Returnerar det värde som hör till söknyckeln.
        /// Om nyckeln inte finns kastas ett KeyNotFoundException
        /// </summary>
        /// <param name="Key">Värdets söknyckel</param>
        /// <returns>det sökta värdet</returns>       
        int Get(string key);

        /// <summary>
        /// Ersätter nodens värde med value
        /// Om nyckeln inte finns kastas ett KeyNotFoundException
        /// </summary>
        /// <param name="key">Värdets söknyckel</param>
        /// <param name="value">Det nya värdet</param>
        void Set(string key, int value);

        /// <summary>
        /// Returnerar en lista med keyvaluepair beroende på 
        /// ordningen angiven med parametern order
        /// </summary>
        /// <param name="order">Sorteringsordning</param>
        /// <returns>En lista sorterad enligt sorteringsordningen.</returns>
        List<KeyValuePair<string, int>> Traverse(SortOrder order);
    }
}