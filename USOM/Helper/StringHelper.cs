using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

namespace USOM.Helper
{
    public static class StringHelper
    {
        public static string GetFullTextSearchString(string searchText)
        {
            string[] separator = { " " };
            string[] words = searchText.Split(separator, StringSplitOptions.None);

            words = words.Where(e => !string.IsNullOrWhiteSpace(e)).ToArray();

            StringBuilder searchTextString = new StringBuilder();

            searchTextString.Append(string.Format(CultureInfo.InvariantCulture, "IsAbout(\"{0}\", ", searchText));
            bool exit = false;

            for (int wordLength = words.Length; wordLength >= 1; wordLength--)
            {
                for (int combinationIndex = 0; combinationIndex <= words.Length - wordLength; combinationIndex++)
                {
                    StringBuilder temp = new StringBuilder();
                    for (int searchWordIndex = combinationIndex;
                         searchWordIndex < wordLength + combinationIndex;
                         searchWordIndex++)
                    {
                        if (searchTextString.Length + temp.Length + words[searchWordIndex].Length > 8000)
                        {
                            exit = true;
                            break;
                        }
                        temp.Append(words[searchWordIndex] + " ");
                    }
                    if (exit)
                    {
                        break;
                    }
                    searchTextString.Append("\"");
                    searchTextString.Append(temp.ToString().Trim());
                    searchTextString.Append("*\", ");
                }

                if (exit)
                {
                    break;
                }
            }
            string returnText = searchTextString.ToString().Trim(',', ' ') + ")";
            return returnText;
        }


        public static string GetImagePath(this string value)
        {
            return !string.IsNullOrEmpty(value) ? $"{ConfigurationManager.AppSettings["AppUrl"]}/uploads/{value}" : $"{ConfigurationManager.AppSettings["AppUrl"]}/content/img/dummyimage.jpg";
        }
    }
}