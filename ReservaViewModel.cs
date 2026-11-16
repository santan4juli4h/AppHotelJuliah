using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;

namespace AppHotelJuliah;

public class ReservaViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public List<string> TiposQuarto { get; } = new()
    {
        "Standard",
        "Luxo",
        "Suíte"
    };

    private string nomeHospede = "";
    public string NomeHospede
    {
        get => nomeHospede;
        set { nomeHospede = value; OnPropertyChanged(); }
    }

    private DateTime dataEntrada = DateTime.Today;
    public DateTime DataEntrada
    {
        get => dataEntrada;
        set { dataEntrada = value; OnPropertyChanged(); }
    }

    private double quantidadeHospedes = 2;
    public double QuantidadeHospedes
    {
        get => quantidadeHospedes;
        set { quantidadeHospedes = value; OnPropertyChanged(); }
    }

    private string tipoQuarto = "Standard";
    public string TipoQuarto
    {
        get => tipoQuarto;
        set { tipoQuarto = value; OnPropertyChanged(); }
    }

    private string resumoReserva = "";
    public string ResumoReserva
    {
        get => resumoReserva;
        set { resumoReserva = value; OnPropertyChanged(); }
    }

    public Command ReservarCommand { get; }

    public ReservaViewModel()
    {
        ReservarCommand = new Command(RealizarReserva);
    }

    private void RealizarReserva()
    {
        if (string.IsNullOrWhiteSpace(NomeHospede))
        {
            ResumoReserva = "Informe o nome do hóspede.";
            return;
        }

        ResumoReserva =
            $"Reserva solicitada para {NomeHospede}! " +
            $"Entrada: {DataEntrada:dd/MM/yyyy}. " +
            $"Hóspedes: {QuantidadeHospedes:F0}. " +
            $"Quarto: {TipoQuarto}.";
    }

    private void OnPropertyChanged(
        [CallerMemberName] string? nome = null)
    {
        PropertyChanged?.Invoke(
            this, new PropertyChangedEventArgs(nome));
    }
}
