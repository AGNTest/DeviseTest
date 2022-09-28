using LuccaDevises.Models;
using System.Globalization;

namespace LuccaDevises
{
    public static class FileReader
    {
        public static ParsedDeviseFile ParseFile(string filePath)
        {
            if (filePath is null)
                throw new ArgumentNullException(nameof(filePath));


            ParsedDeviseFile parsedDeviseFile = new ();

            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length < 2)
                throw new Exception($"Le fichier ${filePath} est mal formaté");

            for (int i = 0; i < lines.Length; i++)
            {
                if (i == 0)
                {
                    var valuesInit = lines[i].Split(';');

                    if (valuesInit.Length != 3)
                        throw new Exception("La ligne 0 du fichier est mal formatée");

                    if (!int.TryParse(valuesInit[1], System.Globalization.NumberStyles.Number, CultureInfo.InvariantCulture, out int startValue))
                        throw new Exception("Le montant de départ est mal formaté");

                    parsedDeviseFile.Source = valuesInit[0];
                    parsedDeviseFile.SourceAmount = startValue;
                    parsedDeviseFile.Target = valuesInit[2];

                    continue;
                }

                if (i == 1)
                {
                    continue;
                }

                var currencyRates = lines[i].Split(';');

                if (currencyRates.Length != 3)
                    throw new Exception($"La ligne {i} du fichier est mal formatée");

                if (!decimal.TryParse(currencyRates[2], NumberStyles.Number, CultureInfo.InvariantCulture, out decimal rate))
                    throw new Exception("Le montant est mal formaté");


                parsedDeviseFile.CurrencyRates.Add(new ParsedCurrencyRate() { CurrencyRate = rate, Source = currencyRates[0], Target = currencyRates[1] });
            }
            return parsedDeviseFile;
        }
    }
}
