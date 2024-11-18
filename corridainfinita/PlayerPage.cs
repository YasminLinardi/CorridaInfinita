using Microsoft.Maui.Platform;

namespace corridainfinita;

public delegate void Callback();
public class Player: AnimacaoPage
{
    public Player (CachedImageView a):base(a)
    {
        for (int i=0; i<=13; ++i)
         Animacao1.Add($"a{i.ToString("D2")}.png");

        SetAnimacaoAtual(1);
    }
    public void Die ()
    {
        loop=false;
        SetAnimacaoAtual(2);
    }
    public void Run ()
    {
        loop=true;
        SetAnimacaoAtual(1);
        Play();
    }
    
    public void MoveY (int s)
    {
        ImageView.TranslationY +=s;
    }

    public double GetY()
    {
        return ImageView.TranslationY;
    }

    public void SetY(double a)
    {
        ImageView.TranslationY = a;
    }

}