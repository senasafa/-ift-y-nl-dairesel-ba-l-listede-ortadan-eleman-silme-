using System;

class Dugum
{
    public int Veri;
    public Dugum Sonraki;
    public Dugum Onceki;

    public Dugum(int veri)
    {
        Veri = veri;
        Sonraki = Onceki = null;
    }
}

class CiftYonluDaireselListe
{
    private Dugum bas;

   
    public void Ekle(int veri)
    {
        Dugum yeniDugum = new Dugum(veri);
        if (bas == null)
        {
            bas = yeniDugum;
            bas.Sonraki = bas;
            bas.Onceki = bas;
        }
        else
        {
            Dugum son = bas.Onceki;
            son.Sonraki = yeniDugum;
            yeniDugum.Onceki = son;
            yeniDugum.Sonraki = bas;
            bas.Onceki = yeniDugum;
        }
    }

   
    public void OrtadanSil(int silinecekVeri)
    {
        if (bas == null) return; // Liste boşsa çık

        Dugum mevcut = bas;

        do
        {
            if (mevcut.Veri == silinecekVeri)
            {
                if (mevcut == bas || mevcut.Sonraki == bas) return; // Baştaki veya sondaki eleman değilse işlem yap

                Dugum oncekiDugum = mevcut.Onceki;
                Dugum sonrakiDugum = mevcut.Sonraki;

                // Önceki düğümü sonraki düğüme bağla
                oncekiDugum.Sonraki = sonrakiDugum;
                sonrakiDugum.Onceki = oncekiDugum;
                return;
            }
            mevcut = mevcut.Sonraki;
        } while (mevcut != bas);
    }

    // listeyi ekrana yazdır
    public void Goster()
    {
        if (bas == null)
        {
            Console.WriteLine("Liste boş.");
            return;
        }

        Dugum temp = bas;
        do
        {
            Console.Write(temp.Veri + " <-> ");
            temp = temp.Sonraki;
        } while (temp != bas);
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        CiftYonluDaireselListe liste = new CiftYonluDaireselListe();

        //  Listeye eleman ekleyelim
        liste.Ekle(5);
        liste.Ekle(10);
        liste.Ekle(15);
        liste.Ekle(20);
        liste.Ekle(25);

        Console.WriteLine("Orijinal Liste:");
        liste.Goster();

        //  Ortadaki elemanı (15) silelim
        Console.WriteLine("15 Silindikten Sonra:");
        liste.OrtadanSil(15);
        liste.Goster();
    }
}
