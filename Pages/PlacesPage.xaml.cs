using System;
using System.Collections.ObjectModel;
using MobileMAUI_2.Model;
using Microsoft.Maui.Controls;

namespace MobileMAUI_2.Pages
{
    public partial class PlacesPage : ContentPage
    {
        private ObservableCollection<Places> places;
        private Places selectedPlace;

        public PlacesPage()
        {
            InitializeComponent();
            places = new ObservableCollection<Places>();  // Initialize with data from your database
            PlacesCollectionView.ItemsSource = places;
        }

        // Add Place Button Clicked
        private async void OnAddPlaceClicked(object sender, EventArgs e)
        {
            PlaceFormFrame.IsVisible = true;  // Show the form
        }

        // Save Button Clicked (Add/Edit)
        private async void OnSavePlaceClicked(object sender, EventArgs e)
        {
            if (selectedPlace == null)  // New Place
            {
                var place = new Places
                {
                    Name = PlaceNameEntry.Text,
                    City = CityEntry.Text,
                    Description = DescriptionEntry.Text
                };
                places.Add(place); // Add to the ObservableCollection
                // Save to the database
            }
            else  // Edit Existing Place
            {
                selectedPlace.Name = PlaceNameEntry.Text;
                selectedPlace.City = CityEntry.Text;
                selectedPlace.Description = DescriptionEntry.Text;
                // Update the place in the database
            }

            ClearForm();
        }

        // Cancel Button Clicked
        private void OnCancelPlaceClicked(object sender, EventArgs e)
        {
            ClearForm();
        }

        // Edit Button Clicked
        private void OnEditPlaceClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            selectedPlace = button?.BindingContext as Places;

            if (selectedPlace != null)
            {
                PlaceNameEntry.Text = selectedPlace.Name;
                CityEntry.Text = selectedPlace.City;
                DescriptionEntry.Text = selectedPlace.Description;
                PlaceFormFrame.IsVisible = true;  // Show the form to edit
            }
        }

        // Delete Button Clicked
        private void OnDeletePlaceClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var place = button?.BindingContext as Places;

            if (place != null)
            {
                places.Remove(place);  // Remove from ObservableCollection
                // Delete from the database
            }
        }

        // On Selection Changed
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                var selectedPlace = e.CurrentSelection[0] as Places;
                // Handle selection logic if needed
            }
        }

        // Clear Form Fields
        private void ClearForm()
        {
            PlaceNameEntry.Text = "";
            CityEntry.Text = "";
            DescriptionEntry.Text = "";
            PlaceFormFrame.IsVisible = false;
            selectedPlace = null;
        }
    }
}
