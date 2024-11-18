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
	Player player;

	public MainPage()
	{
		InitializeComponent();
		player=new Player(animacao);
		player.Run();
	}

	async Task Desenhar()
	{
		while (!estamorto)
		{
			GerenciaImagens();
			player.Desenha();
			await Task.Delay(tempoentreframes);
		}
	}

	void GerenciaImagens(HorizontalStackLayout HSL)
	{
		var view = (HSL.Children.First() as Image);
		if (view.WidthRequest + HSL.TranslationX <0)
		{
			HSL.Children.Remove(view);
			HSL.Children.Add(view);
			HSL.TranslationX=view.TranslationX;
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
		Desenhar();
	}
	void CalculaVelocidade(double w)
	{
		velocidade = (int)(w * 0.01);
		velocidade1 = (int)(w * 0.002);
		velocidade2 = (int)(w * 0.004);
		velocidade3 = (int)(w * 0.008);
	}

	void CorrigeTamanho(double w, double h)
	{
		foreach (var a in Layer1.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in Layer2.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in Layerchao.Children)
			(a as Image).WidthRequest = w;

		Layer1.WidthRequest = w;
		Layer2.WidthRequest = w;
		Layerchao.WidthRequest = w;
	}

	void MoveCenario()
	{
		Layer1.TranslationX-=velocidade1;
		Layer2.TranslationX-=velocidade2;
        Layerchao.TranslationX-=velocidade;
	}

	void GerenciaImagens()
	{
		MoveCenario();
		GerenciaImagens(Layer1);
		GerenciaImagens(Layer2);
		GerenciaImagens(Layerchao);
	}
}
