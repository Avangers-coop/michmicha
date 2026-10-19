using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Evaluation_Sommative_UA1
{
    public partial class MainWindow : Window
    {
        ObservableCollection<OffreStage> listeOffres;

        public MainWindow()
        {
            InitializeComponent();

            listeOffres = new ObservableCollection<OffreStage>();

            dgOffres.ItemsSource = listeOffres;
        }

        private void Publier_Click(object sender, RoutedEventArgs e)
        {
            if (txtEntreprise.Text == "" ||
                txtPoste.Text == "" ||
                txtLieu.Text == "" ||
                txtDescription.Text == "" ||
                dateDebut.SelectedDate == null ||
                dateFin.SelectedDate == null)
            {
                MessageBox.Show(
                    "Veuillez remplir tous les champs obligatoires.",
                    "Attention",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            if (dateFin.SelectedDate < dateDebut.SelectedDate)
            {
                MessageBox.Show(
                    "La date de fin doit être après la date de début.");

                return;
            }

            int nombre;

            if (!int.TryParse(txtNombre.Text, out nombre) || nombre < 1)
            {
                MessageBox.Show(
                    "Veuillez entrer un nombre de postes valide.");

                return;
            }

            string programme = "";

            if (cmbProgramme.SelectedItem is ComboBoxItem elementProgramme)
            {
                programme = elementProgramme.Content.ToString();
            }

            string type = "";

            if (cmbType.SelectedItem is ComboBoxItem elementType)
            {
                type = elementType.Content.ToString();
            }

            string statut = "";

            if (cmbStatut.SelectedItem is ComboBoxItem elementStatut)
            {
                statut = elementStatut.Content.ToString();
            }

            OffreStage nouvelleOffre = new OffreStage
            {
                Entreprise = txtEntreprise.Text,
                Poste = txtPoste.Text,
                Programme = programme,
                Type = type,
                Lieu = txtLieu.Text,
                Debut = dateDebut.SelectedDate.Value,
                Fin = dateFin.SelectedDate.Value,
                Nombre = nombre,
                Description = txtDescription.Text,
                Statut = statut
            };

            listeOffres.Add(nouvelleOffre);

            MessageBox.Show(
                "L'offre a été publiée avec succès !",
                "Confirmation",
                MessageBoxButton.OK,
                MessageBoxImage.Information);

            ReinitialiserFormulaire();
        }

        private void Reinitialiser_Click(object sender, RoutedEventArgs e)
        {
            ReinitialiserFormulaire();
        }

        private void ReinitialiserFormulaire()
        {
            txtEntreprise.Clear();
            txtPoste.Clear();
            txtLieu.Clear();
            txtDescription.Clear();

            cmbProgramme.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
            cmbStatut.SelectedIndex = 0;

            txtNombre.Text = "1";

            dateDebut.SelectedDate = null;
            dateFin.SelectedDate = null;
        }
    }

    public class OffreStage
    {
        public string Entreprise { get; set; }
        public string Poste { get; set; }
        public string Programme { get; set; }
        public string Type { get; set; }
        public string Lieu { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }
        public int Nombre { get; set; }
        public string Description { get; set; }
        public string Statut { get; set; }
    }
}