using System;
using System.Collections.ObjectModel;
using MobileMAUI_2.Model;
using Microsoft.Maui.Controls;

namespace MobileMAUI_2.Pages
{
    public partial class FoodPage : ContentPage
    {
        private ObservableCollection<Food> foods;
        private Food selectedFood;

        public FoodPage()
        {
            InitializeComponent();
            foods = new ObservableCollection<Food>();  // Initialize with data from your database
            FoodCollectionView.ItemsSource = foods;
        }

        // Add Food Button Clicked
        private async void OnAddFoodClicked(object sender, EventArgs e)
        {
            FoodFormFrame.IsVisible = true;  // Show the form
        }

        // Save Button Clicked (Add/Edit)
        private async void OnSaveFoodClicked(object sender, EventArgs e)
        {
            if (selectedFood == null)  // New Food
            {
                var food = new Food
                {
                    Name = FoodNameEntry.Text,
                    Description = FoodDescriptionEntry.Text,
                    Rating = int.Parse(RatingEntry.Text)
                };
                foods.Add(food); // Add to the ObservableCollection
                // Save to the database
            }
            else  // Edit Existing Food
            {
                selectedFood.Name = FoodNameEntry.Text;
                selectedFood.Description = FoodDescriptionEntry.Text;
                selectedFood.Rating = int.Parse(RatingEntry.Text);
                // Update the food in the database
            }

            ClearForm();
        }

        // Cancel Button Clicked
        private void OnCancelFoodClicked(object sender, EventArgs e)
        {
            ClearForm();
        }

        // Edit Button Clicked
        private void OnEditFoodClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            selectedFood = button?.BindingContext as Food;

            if (selectedFood != null)
            {
                FoodNameEntry.Text = selectedFood.Name;
                FoodDescriptionEntry.Text = selectedFood.Description;
                RatingEntry.Text = selectedFood.Rating.ToString();
                FoodFormFrame.IsVisible = true;  // Show the form to edit
            }
        }

        // Delete Button Clicked
        private void OnDeleteFoodClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var food = button?.BindingContext as Food;

            if (food != null)
            {
                foods.Remove(food);  // Remove from ObservableCollection
                // Delete from the database
            }
        }

        // On Selection Changed
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                var selectedFood = e.CurrentSelection[0] as Food;
                // Handle selection logic if needed
            }
        }

        // Clear Form Fields
        private void ClearForm()
        {
            FoodNameEntry.Text = "";
            FoodDescriptionEntry.Text = "";
            RatingEntry.Text = "";
            FoodFormFrame.IsVisible = false;
            selectedFood = null;
        }
    }
}
