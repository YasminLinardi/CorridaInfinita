namespace corridainfinita;

public partial class MainPage : ContentPage
{
	bool estamorto = false;
	bool estapulando = false;
	bool estaNoChao = true;
	bool estaNoAr = false;
	const int forcaGravidade = 6;
	const int forcaPulo = 8;
	const int maxTempoPulando = 6;
	const int masTempoNoAr = 4;
	const int tempoEntreFrames = 25;
	int velocidade = 0;
	int velocidade1 = 0;
	int velocidade2 = 0;
	int velocidade3 = 0;
	int larguraJanela = 0;
	int alturaJanela = 0;
	int tempoPulando = 0;
	int tempoNoAr = 0;
	Player player;

	public MainPage()
	{
		InitializeComponent();
		player=new Player(animacao);
		player.Run();
	}

	async Task Desenha()
	{
		while (!estamorto)
		{
			GerenciaImagens();
			if(!estapulando && !estaNoAr)
			{
				AplicaGravidade();
				Player.Desenha();
			}
			else
				AplicaPulo();

			await Task.Delay(tempoEntreFrames);
		
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

	void AplicaGravidade()
	{
		if(player.GetY()<0)
		player.MoveY(forcaGravidade);
		else if (player.GetY()>=0)
		{
			player.SetY(0);
			estaNoChao = true;
		}
	}

	void AplicaPulo()
	{
		estaNoChao=false;
		if (estapulando && tempoPulando>=maxTempoPulando)
		{
			estapulando = false;
			estaNoAr = true;
			tempoPulando = 0;
		}
		else if (estsNoAr && tempoNoAr >= maxTempoNoAr)
		{
			estaPulando = false;
			estaNoAr = false;
			tempoPulando = 0;
			tempoNoAr = 0;
		}
		else if (estaPulando && tempoPulando < maxTempoPulando)
		{
			player.MoveY (-forcaPulo);
			tempoPulando ++;
		}
		else if (estaNoAr)
			tempoNoAr ++;
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

	void OnGridTapped (object o, TappedEventArgs a)
	{
		if(estaNoChao)
		   estapulando = true;
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
