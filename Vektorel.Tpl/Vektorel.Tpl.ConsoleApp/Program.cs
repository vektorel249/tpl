
namespace Vektorel.Tpl.ConsoleApp
{
    internal class Program
    {
        static List<int> oneThousands = new List<int>();
        static List<int> fiveThousands = new List<int>();
        static void Main(string[] args)
        {
            var t1 = Task.Run(() => { FindOneThousands(); });
            var t2 = Task.Run(() => { FindFiveThousands(); });

            //t1 ve t2'yi aynı anda başlat ve ikisinin de bitmesini bekle
            Task.WhenAll(t1, t2).Wait();

            //t1 ve t2'yi aynı anda başlat ve herhangi biri bitince devam et
            //Task.WhenAny(t1, t2).Wait();

            //CancellationToken: Bir Task'ın çalışırken dışarıdan durma sinyali gönderme tipidir
            Console.WriteLine("Bitti");
        }

        private static Task FindFiveThousands()
        {
            for (int i = 0; i < 100000; i++)
            {
                if (i % 5000 == 0)
                {
                    fiveThousands.Add(i);
                    Console.WriteLine($"Binlik Sayısı: {oneThousands.Count}, Beşbinlik Sayısı: {fiveThousands.Count}");
                }
            }
            return Task.CompletedTask;
        }

        private static Task FindOneThousands()
        {
            for (int i = 0; i < 100000; i++)
            {
                if (i % 1000 == 0)
                {
                    oneThousands.Add(i);
                    Console.WriteLine($"Binlik Sayısı: {oneThousands.Count}, Beşbinlik Sayısı: {fiveThousands.Count}");
                }
            }
            return Task.CompletedTask;
        }
    }
}
