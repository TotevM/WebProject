namespace FitnessApp.Common
{
    public static class EntityValidationConstants
    {
        public static class UserValidation
        {
            public const int UsernameMinLength = 3;
            public const int UsernameMaxLength = 32;

            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 32;
        }

        public static class DietValidation
        {
            public const int DietNameMinLength = 3;
            public const int DietNameMaxLength = 32;

            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 300;
        }

        public static class ExerciseValidation
        {
            public const int ExerciseNameMinLength = 3;
            public const int ExerciseNameMaxLength = 32;
        }

        public static class FoodValidation
        {
            public const int FoodNameMinLength = 3;
            public const int FoodNameMaxLength = 32;

            public const int CalsMax = 1_000;
            public const int ProteinMax = 100;
            public const int CarbsMax = 100;
            public const int FatsMax = 100;
        }

        public static class ProgressValidation
        {
            public const int WeightMax = 300;
            public const int WeightMin = 25;

            public const int HeightMin = 100;
            public const int HeightMax = 256;
        }

        public static class RecipeValidation
        {
            public const int RecipeNameMinLength = 3;
            public const int RecipeNameMaxLength = 32;

            public const int IngredientsNameMinLength = 3;
            public const int IngredientsNameMaxLength = 512;

            public const int PreparationNameMinLength = 16;
            public const int PreparationNameMaxLength = 1024;
        }

        public static class WorkoutValidation
        {
            public const int WorkoutNameMinLength = 3;
            public const int WorkoutNameMaxLength = 32;

            public const string WorkoutMinPrice = "3";
            public const string WorkoutMaxPrice = "512";
        }
    }
}
