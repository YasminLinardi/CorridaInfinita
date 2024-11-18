namespace corridainfinita;

public partial class AnimacaoPage 
{
    protected List<String> Animacao1 =new List<string>();
    protected List<String> Animacao2 =new List<string>();
    protected List<String> Animacao3 =new List<string>();
    protected bool loop=true;
    protected int AnimacaoAtiva =1;
    bool parado=true;
    int frameAtual=1;
    protected CachedImageView compImagem;

    public AnimacaoPage(CachedImageView a)
	{
		compImagem=a;
	}

    public void Stop()
    {
        parado=true;
    }

    public void Play ()
    {
        parado=false;
    }

    public void SetAnimacaoAtual(int a)
    {
        AnimacaoAtiva=a;
    }

    public void Desenha()
    {
        if(parado)
        return;
        string nomeArquivo="";
        int tamanhoAnimacao=0;
        if(AnimacaoAtiva==1)
        {
            nomeArquivo=Animacao1[frameAtual];
            tamanhoAnimacao=Animacao1.Count;
        }
        else if(AnimacaoAtiva==2)
        {
            nomeArquivo=Animacao2[frameAtual];
            tamanhoAnimacao=Animacao2.Count;
        }
        else if(AnimacaoAtiva==3)
        {
            nomeArquivo=Animacao3[frameAtual];
            tamanhoAnimacao=Animacao3.Count;
        }
        compImagem.Source=ImageSource.FromFile(nomeArquivo);
        frameAtual++;
        
        if(frameAtual >= tamanhoAnimacao)
        {
            if(loop)
            frameAtual=0;
            else
            {
                parado=true;
                QuandoParar();
            }
        }
    }

    public virtual void QuandoParar()
    {
        
    }

}