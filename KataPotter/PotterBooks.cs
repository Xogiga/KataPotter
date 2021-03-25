using System;
using System.Collections.Generic;
using System.Linq;

namespace CodePotter
{
    public class PotterBooks
    {
        static void Main(string[] args)
        {

        }

        /// <summary>
        /// Finds the best price for a given list of books
        /// </summary>
        /// <param name="books">List of books represented by integers from 1 to 5</param>
        public static double PriceAllBooks (List<int> books)
        {
            double price = 0;
            
            if (books.Count() > 0)
            {
                List<double> pricesList = getAllPossiblePrices(books);

                price = pricesList.Min();
            }

            
            return price;
        }

        /// <summary>
        /// Finds all possible prices for a given list of books
        /// </summary>
        /// <param name="books">List of books represented by integers from 1 to 5</param>
        /// <returns>A list of prices</returns>
        private static List<double> getAllPossiblePrices(List<int> books)
        {
            List<double> possiblePrices = new List<double>();

            List<List<int>> grouppedBooks = new List<List<int>>();
            grouppedBooks = groupBooks(books);
            double listPrice;
            double groupPrice;

            foreach (List<int> lg in grouppedBooks)
            {
                listPrice = default;
                foreach (int group in lg)
                {
                    groupPrice = getGroupPrice(group);
                    listPrice += groupPrice;
                    
                }
                possiblePrices.Add(listPrice);
            }

            return possiblePrices;
        }

        /// <summary>
        /// Returns the price of a group of distinct books, including the discount
        /// </summary>
        /// <param name="booksNumber">The number of books in the group</param>
        private static double getGroupPrice(int booksNumber)
        {
            double groupPrice = default;
            int unitPrice = 8;

            switch (booksNumber)
            {
                case 1:
                    groupPrice = unitPrice;
                    break;
                case 2:
                    groupPrice = unitPrice * 2 * 0.95;
                    break;
                case 3:
                    groupPrice = unitPrice * 3 * 0.9;
                    break;
                case 4:
                    groupPrice = unitPrice * 4 * 0.8;
                    break;
                case 5:
                    groupPrice = unitPrice * 5 * 0.75;
                    break;
                default:
                    break;

            }

            return groupPrice;
        }

        /// <summary>
        /// Returns a list of all the possible books grouping, each value representing a set of distinct books
        /// </summary>
        /// <param name="books">List of books represented by integers from 1 to 5</param>
        /// <returns>List of possible lists of books groupings</returns>
        private static List<List<int>> groupBooks(List<int> books)
        {
            List<List<int>> grouppedBooks = new List<List<int>>();

            List<List<List<int>>> bigFuckinMatrix = getMatrixOfPossibleBooksCombos(books);

            foreach(List<List<int>> l in bigFuckinMatrix)
            {
                List<int> newTmpList = new List<int>();
                foreach (List<int> ll in l)
                {
                    newTmpList.Add(ll.Count);
                }
                grouppedBooks.Add(newTmpList);
            }

            return grouppedBooks;
        }

        /// <summary>
        /// Returns a 3D matrix of all the possible books groupings, with each group having distinct books only
        /// </summary>
        /// <param name="books">List of books represented by integers from 1 to 5</param>
        private static List<List<List<int>>> getMatrixOfPossibleBooksCombos(List<int> books)
        {
            List<List<List<int>>> finalMatrix = new List<List<List<int>>>();

            for (int i = 1; i <= books.Distinct().Count(); i++)
            {
                List<List<int>> tmpGroups = new List<List<int>>();

                foreach (int b in books)
                {
                    IEnumerable<List<int>> groupsWithoutBook = getGroupsWithoutBook(tmpGroups, b);

                    List<int> tmpGroup = groupsWithoutBook.FirstOrDefault(g => g.Count < i);
                    if (tmpGroup != null)
                    {
                        tmpGroup.Add(b);
                    }
                    else
                    { 
                        tmpGroups.Add(new List<int> { b });
                    }
                }

                finalMatrix.Add(tmpGroups);
            }

            return finalMatrix;
        }

        /// <summary>
        /// returns all the groups of a list that do not contain a given book
        /// </summary>
        private static IEnumerable<List<int>> getGroupsWithoutBook(List<List<int>> bookGroups, int book)
        {
            return bookGroups.Where(bg => !bg.Contains(book));
        }
    }
}
