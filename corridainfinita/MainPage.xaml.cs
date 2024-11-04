namespace corridainfinita;

public partial class MainPage : ContentPage
{
	bool estamorto = false;
	bool estapulando = false;
	const int tempoentreframes = 25;
	int velocidade = 0;
	int velocidade1 = 0;
	int velocidade2 = 0;
	int velocidade3 = 0;
	int larguraJanela = 0;
	int alturaJanela = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	async Task Desenha()
	{
		while (!estamorto)
		{
			GerenciaCenarios();
			await Task.Delay (tempoentreframes);
		}
	}

	protected override void OnSizeAllocated(double w, double h)
	{
		base.OnSizeAllocated(w, h);
		CalculaVelocidade(w);
		CorrigeTamanho(w, h);
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		Desenha();
	}
	void CalculaVelocidade(double w)
	{
		velocidade = (int)(w * 0.01);
		velocidade1 = (int)(w * 0.001);
		velocidade2 = (int)(w * 0.004);
		velocidade3 = (int)(w * 0.008);
	}

	void CorrigeTamanho(double w, double h)
	{
		foreach (var a in Layer1.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in Layer2.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in LayerChao.Children)
			(a as Image).WidthRequest = w;

		Layer1.WidthRequest = w;
		Layer2.WidthRequest = w;
		LayerChao.WidthRequest = w;
	}

	void GerenciaCenarios()
	{
		MoveCenerio();
		GerenciaCenario(Layer1);
		GerenciaCenario(Layer2);
		GerenciaCenario(LayerChao);
	}

	void MoveCenerio()
	{
		Layer1.TranslationX -= velocidade1;
		Layer2.TranslationX -= velocidade2;
		LayerChao.TranslationX -= velocidade;
	}

	void GerenciaCenario(HorizontalStackLayout hsl)
	{
		var view = (hsl.Children.First() as Image);
		if(view.WidthRequest+hsl.TranslationX < 0)
		{
			hsl.Children.Remove(view);
			hsl.Children.Add(view);
			hsl.TranslationX = view.TranslationX;
		}

	}

	
}
