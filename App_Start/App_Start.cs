
using CalorieCount.DataBase;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CalorieCount.App_Start), "PreStart")]

namespace CalorieCount {
    public static class App_Start {
        public static void PreStart() {
        }
    }
}