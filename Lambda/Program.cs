using System;

namespace Lambda {
    class Program {
        static void Main (string[] args) {
            // Func <int, int, double> res = Atividade.Subtrair;
            // Console.WriteLine(res(10,5));
            // Func <int, int, string> ser = Atividade.multiplicar;
            // Console.WriteLine(ser(10,5));

            // Action<int, int> res = Soma;
            // res (20, 2);

            // Predicate <int> res = parImpar;
            // Console.WriteLine (res(30));

            //     Data dt = delegate (string msg) {
            //         return msg + " hoje é " + DateTime.Now;
            //     };
            //     Console.WriteLine(dt("Olá sexta-feira"));

            // int[] valor = { 1, 54, 22, 45, 32, 2, 11, 43, 65, 64 };

            // Func<int, bool> rs = x => x % 2 == 0;

            // foreach (var i in valor) {
            //     if (rs (i)) {
            //         Console.WriteLine (i);
            //     }
            // }

            Func<double, double, double> calculo = (x,y) => x/y;
            Console.WriteLine(calculo(5,2));

        }
        // static bool Par (int v) {
        //     return v % 2 == 0;
        // }
        // static void Soma (int v1, int v2) {
        //     Console.WriteLine (v1 + v2);
        // }
        // static bool parImpar (int valor) {
        //     return valor % 2 == 0;
        // }

        // delegate string Data (string msg);

    }
}