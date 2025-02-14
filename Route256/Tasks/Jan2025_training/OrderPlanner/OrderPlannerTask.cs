using System.Text;

namespace Route256.Tasks;

public class OrderPlannerTask : IContestTask
{
    public void Run(TextReader input, TextWriter output)
    {
        // 1. Сортируем заказы по возрастанию.
        // 2. Сортируем машины по времени прибытия, если время прибытия совпадает, то сортируем по номеру машины в массиве.
        // 3. Идем циклом по машинам. Внутри цикла идем по заказам, начиная со значения последнего нераспределенного заказа (shift).
        //
        //    Если у машины закончилось место или она уже уехала - переходим к следующей машине.
        //    Иначе
        //    Если заказ попадает в интервал машины - заказу ставим в соответствие номер текущей машины. Уменьшаем capacity. Обновляем shift на следующий заказ.

        int t = int.Parse(input.ReadLine()!);

        for (int k = 0; k < t; k++)
        {
            int n = int.Parse(input.ReadLine()!);

            var arrivals = input.ReadLine()!.Split(' ').Select(int.Parse);
            var orderedArrivals = arrivals.Order().ToArray();
            Dictionary<int, int> result = new();

            int m = int.Parse(input.ReadLine()!);

            var cars = new List<Car>();

            for (int j = 0; j < m; j++)
            {
                var carData = input.ReadLine()!.Split(' ').Select(int.Parse).ToArray();

                cars.Add(new Car
                {
                    Number = j + 1,
                    Start = carData[0],
                    End = carData[1],
                    Capacity = carData[2]
                });
            }
            cars = cars.OrderBy(car => car.Start).ThenBy(car => car.Number).ToList();

            int shift = 0;

            for (int i = 0; i < m; i++) // cars
            {
                var car = cars[i];

                for (int j = shift; j < n; j++) // arrivals
                {
                    int arrival = orderedArrivals[j];

                    if (car.Capacity == 0 || car.End < arrival)
                    {
                        break;
                    }
                    if (car.Start <= arrival && car.End >= arrival)
                    {
                        result[arrival] = car.Number;
                        car.Capacity--;
                        shift = j + 1;
                    }
                }
            }

            var sb = new StringBuilder();

            foreach (var a in arrivals)
            {
                sb.Append(result.TryGetValue(a, out int carNumber) ? carNumber : -1);
                sb.Append(' ');
            }

            output.WriteLine(sb.ToString());
        }
    }

    class Car
    {
        public int Number { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public int Capacity { get; set; }
    }
}
