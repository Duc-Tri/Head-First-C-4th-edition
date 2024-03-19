using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChefSecretIngredients
{
    internal class Harper
    {
        // The HarpersSecretIngredientMethod property returns a new instance of the GetSecretIngredient delegate that’s pointing to her secret ingredient method.
        public GetSecretIngredient HarperSecretIngredientMethod
        {
            get
            {
                return AddHarperSecretIngredient;
            }
        }

        private int total = 20;

        // Harper’s secret ingredient method also takes an int called amount and returns a string, but it returns a different string from Adrian’s.
        private string AddHarperSecretIngredient(int amount)
        {
            if (total - amount < 0)
            {
                return $"I don't have {amount} cans of sardines !";
            }
            else
            {
                total -= amount;
                return $"{amount} cans of sardines";
            }
        }

    }
}
