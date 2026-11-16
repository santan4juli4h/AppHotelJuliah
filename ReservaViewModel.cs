using System.ComponentModel;
using System.Windows.Input;

namespace AppHotelJuliah;

public class ReservaViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public List<string> TiposQuarto { get; } = new()
    {
        "Quarto simples",
        "Quarto duplo",
        "Suíte luxo"
    };

    private string nomeHospede = "";
    public string NomeHospede
    {
        get => nomeHospede;
        set
        {
            nomeHospede = value;
            OnPropertyChanged(nameof(NomeHospede));
        }
    }

    private string tipoQuarto = "";
    public string TipoQuarto
    {
        get => tipoQuarto;
        set
        {
            tipoQuarto = value;
            OnPropertyChanged(nameof(TipoQuarto));
        }
    }

    private DateTime dataEntrada = DateTime.Today;
    public DateTime DataEntrada
    {
        get => dataEntrada;
        set
        {
            dataEntrada = value;
            OnPropertyChanged(nameof(DataEntrada));
        }
    }

    private double quantidadeHospedes = 1;
    public double QuantidadeHospedes
    {
        get => quantidadeHospedes;
        set
        {
            quantidadeHospedes = value;
            OnPropertyChanged(nameof(QuantidadeHospedes));
        }
    }

    private string resumoReserva = "";
    public string ResumoReserva
    {
        get => resumoReserva;
        set
        {
            resumoReserva = value;
            OnPropertyChanged(nameof(ResumoReserva));
        }
    }

    public ICommand ReservarCommand { get; }

    public ReservaViewModel()
    {
        ReservarCommand = new Command(ConfirmarReserva);
    }

    private void ConfirmarReserva()
    {
        if (string.IsNullOrWhiteSpace(NomeHospede) ||
            string.IsNullOrWhiteSpace(TipoQuarto))
        {
            ResumoReserva = "Preencha seu nome e escolha um quarto.";
            return;
        }

        ResumoReserva =
            $"Reserva solicitada!\n" +
            $"Hóspede: {NomeHospede}\n" +
            $"Quarto: {TipoQuarto}\n" +
            $"Entrada: {DataEntrada:dd/MM/yyyy}\n" +
            $"Hóspedes: {QuantidadeHospedes:0}";
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));
    }
}
