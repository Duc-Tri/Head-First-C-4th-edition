namespace ChefSecretIngredients
{
    internal class Adrian
    {
        public GetSecretIngredient MySecretIngredientMethod
        {
            get
            {
                return AddAdrianSecretIngredient;
            }
        }

        private string AddAdrianSecretIngredient(int amount)
        {
            // Adrian’s secret ingredient method takes an int called amount and returns a string that describes her secret ingredient.
            return $"{amount} ounces of cloves";
        }

    }
}
