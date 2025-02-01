namespace Route256.Tasks.Main;

public class ValidateProductsTask : IContestTask
{
    public void Run(TextReader input, TextWriter output)
    {
        int t = int.Parse(input.ReadLine()!);

        for (int k = 0; k < t; k++)
        {
            int n = int.Parse(input.ReadLine()!);
            var prices = new HashSet<string>();
            var names = new HashSet<string>();
            var products = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                var inputArray = input.ReadLine()!.Split(' ');
                string name = inputArray[0];
                string price = inputArray[1];
                names.Add(name);
                prices.Add(price);
                products[name] = price;
            }

            string str = input.ReadLine()!;
            bool error = false;
            var addedNames = new HashSet<string>();
            var addedPrices = new HashSet<string>();

            foreach (string product in str.Split(','))
            {
                try
                {
                    if (error) break;

                    var arr = product.Split(':');

                    // неверный формат товара
                    error |= arr.Length != 2;

                    (string name, string price) = (arr[0], arr[1]);

                    // несуществующее имя
                    error |= !names.Contains(name);

                    // повторяющееся имя
                    error |= addedNames.Contains(name);
                    addedNames.Add(name);

                    // неверный формат имени
                    error |= !name.All(char.IsAsciiLetterLower);

                    // ведущие нули
                    error |= price.StartsWith('0');

                    // несуществующая цена
                    error |= !prices.Contains(price);

                    // повторяющаяся цена
                    error |= addedPrices.Contains(price);
                    addedPrices.Add(price);

                    // смена цен местами
                    error |= products[name] != price;
                }
                catch
                {
                    error = true;
                }
            }

            output.WriteLine(!error && addedPrices.Count == prices.Count ? "YES" : "NO");
        }
    }
}
