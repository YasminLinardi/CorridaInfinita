namespace corridainfinita;

public class Animacao
	{
		protected List<String> animacao1 = new List<string>();
		protected List<String> animacao2 = new List<string>();
		protected List<String> animacao3 = new List<string>();
		protected bool loop = true;
		protected int animacaoAtiva = 1;
		bool parado = true;
		int frameAtual = 1;
		protected Image compImagem;

		public Animacao(Image a)
        {
            compImagem = a;
        }

        public void Stop()
        {
            parado = true;
        }

        public void Play()
        {
            parado = false;
        }

        public void SetAnimacaoAtiva(int a)
        {
            animacaoAtiva = a;
        }

        public void Desenha()
        {
            if(parado)
                return;
            
            string nomeArquivo="";
            int tamanhoAnimacao = 0;
            if (animacaoAtiva ==1)
            {
                nomeArquivo = animacao1.Count;
                nomeAnimacao = animacao2.Count;
            }
        }
	}