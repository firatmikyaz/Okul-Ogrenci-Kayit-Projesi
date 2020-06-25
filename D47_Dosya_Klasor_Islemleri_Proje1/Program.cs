using System;
using System.IO;
using System.Linq;

namespace D47_Dosya_Klasor_Islemleri_Proje1
{
    class Program
    {
        static void Main(string[] args)
        {
        BASADON:
            Console.WriteLine("1-Yeni Öğrenci Kaydı");
            Console.WriteLine("2-Öğrenci Bilgilerini Güncelleme");
            Console.WriteLine("3-Öğrenci Kaydı Silme");
            Console.WriteLine("4-Öğrenci Sınıf Değişikliği");
            Console.WriteLine("5-Çıkış");

            Console.Write("Seçiminizi Yapınız? [1,2,3,4,5]");
            string secim = Console.ReadLine().ToUpper();

            string ogrno, sinif, sinif_klasor_yolu, ogrenci_klasor_yolu;

            switch (secim) 
            {
                case "1":
                    Console.WriteLine("Öğrenci numarasını giriniz?");
                    ogrno = Console.ReadLine();
                    Console.WriteLine("Kayıt olunacak sınıfı seçiniz?[10-A,10-B,10-C]");
                    sinif = Console.ReadLine();
                    sinif_klasor_yolu = @"c:\Okul\" + sinif;
                    ogrenci_klasor_yolu = @"c:\Okul\" + sinif + "\\" + ogrno;

                    if (System.IO.Directory.Exists(sinif_klasor_yolu)==true && System.IO.Directory.Exists(ogrenci_klasor_yolu)==false)
                    {
                        System.IO.Directory.CreateDirectory(ogrenci_klasor_yolu);
                        string dosya_adi = ogrno + ".txt";
                        string hedef_dosya_yolu = System.IO.Path.Combine(ogrenci_klasor_yolu, dosya_adi);
                        System.IO.File.Create(hedef_dosya_yolu).Close();
                        Console.WriteLine("{0} numaralı öğrenci için klasör ve dosya oluşturulmuştur.",ogrno);

                        string ad, soyad, cinsiyet, telno, adres;
                        Console.Write("Adı:");
                        ad = Console.ReadLine();
                        Console.Write("Soyadı:");
                        soyad = Console.ReadLine();
                        Console.Write("Cinsiyet:");
                        cinsiyet = Console.ReadLine();
                        Console.Write("Tel No:");
                        telno = Console.ReadLine();
                        Console.Write("Adres:");
                        adres = Console.ReadLine();

                        string[] ogrencibilgileri = { "Öğrenci No:" + ogrno, "Adı:" + ad, "Soyadı:" + soyad, "Cinsiyeti:" + cinsiyet, "Tel No:" + telno, "Adresi:" + adres };
                        System.IO.File.WriteAllLines(@"c:\Okul\" + sinif + "\\" + ogrno + "\\" + ogrno + ".txt", ogrencibilgileri);
                        Console.Clear();
                        Console.WriteLine("Öğrenci Bilgileri başarı ile kaydedilmiştir.");
                        goto BASADON;
                    }
                    if (System.IO.Directory.Exists(sinif_klasor_yolu)==false)
                    {
                        Console.Clear();
                        Console.WriteLine("Okulda {0} sınıf yoktur.",sinif);
                        goto BASADON;
                    }
                    if (System.IO.Directory.Exists(ogrenci_klasor_yolu)==true)
                    {
                        Console.Clear();
                        Console.WriteLine("Okulda {0} sınıfında {1} numaralı öğrenci zaten mevcuttur.", sinif, ogrno);
                        goto BASADON;
                    }
                    break;

                case "2":
                    Console.Write("Öğrenci numarasını giriniz?");
                    ogrno = Console.ReadLine();
                    System.IO.DirectoryInfo klasor_bilgisi = new DirectoryInfo("c:\\Okul");
                    System.IO.FileInfo[] dosyalar = klasor_bilgisi.GetFiles(ogrno + ".txt", System.IO.SearchOption.AllDirectories);
                    int adet = dosyalar.Count();
                    if (adet > 0)
                    {
                        string ogrenci_dosya_yolu = dosyalar[0].DirectoryName;
                        string ogrenci_dosya_adi = ogrno + ".txt";
                        string ogrenci_hedef_yolu = System.IO.Path.Combine(ogrenci_dosya_yolu, ogrenci_dosya_adi);
                        string[] ogrenci_bilgileri = System.IO.File.ReadAllLines(ogrenci_hedef_yolu);
                        foreach (string satirlar in ogrenci_bilgileri)
                        {
                            Console.WriteLine(satirlar);
                        }


                    GUNCELLE:
                        Console.WriteLine("1-Telefon No Giriniz?");
                        Console.WriteLine("2-Adres giriniz?");
                        Console.Write("Hangi Bilgi Güncellenecektir? [1,2]");
                        string guncelleme_menusu = Console.ReadLine();
                        if (guncelleme_menusu == "1")
                        {
                            Console.Write("Telefon No giriniz?");
                            ogrenci_bilgileri[4] = "Telefon No:" + Console.ReadLine();
                            System.IO.File.WriteAllLines(ogrenci_hedef_yolu, ogrenci_bilgileri);
                            Console.Write("Telefon No Güncellenmiştir.");
                            foreach (string satirlar in ogrenci_bilgileri)
                            {
                                Console.WriteLine(satirlar);
                            }
                            Console.Write("Başka Bir bilgi Güncellenecek mi? (e=evet veya h=hayır)");
                            string guncelleme_devam = Console.ReadLine();
                            if (guncelleme_devam == "e")
                            {
                                goto GUNCELLE;
                            }
                            else if (guncelleme_devam == "h")
                            {
                                Console.Clear();
                                goto BASADON;
                            }
                            else
                            {
                                Console.Clear();
                                Console.Write("Yanlış menü seçimi yaptınız!");
                                goto BASADON;
                            }

                        }

                        if (guncelleme_menusu == "2")
                        {
                            Console.Write("Adres giriniz?");
                            ogrenci_bilgileri[5] = "Adres:" + Console.ReadLine();
                            System.IO.File.WriteAllLines(ogrenci_hedef_yolu, ogrenci_bilgileri);
                            Console.Write("Adres Güncellenmiştir.");
                            foreach (string satirlar in ogrenci_bilgileri)
                            {
                                Console.WriteLine(satirlar);
                            }
                            Console.Write("Başka Bir bilgi Güncellenecek mi? (e=evet veya h=hayır)");
                            string guncelleme_devam = Console.ReadLine();
                            if (guncelleme_devam == "e")
                            {
                                goto GUNCELLE;
                            }
                            else if (guncelleme_devam == "h")
                            {
                                Console.Clear();
                                goto BASADON;
                            }
                            else
                            {
                                Console.Clear();
                                Console.Write("Yanlış menü seçimi yaptınız!");
                                goto BASADON;
                            }

                        }
                    }
                    break;

                case "3":
                    Console.Write("Öğrenci Numarasını Giriniz?");
                    ogrno = Console.ReadLine();
                    System.IO.DirectoryInfo silinecekklasorbilgisi = new System.IO.DirectoryInfo("c:\\Okul");
                    System.IO.FileInfo[] dosya_dizisi = silinecekklasorbilgisi.GetFiles(ogrno + ".txt", System.IO.SearchOption.AllDirectories);
                    int bulunandosyaadeti = dosya_dizisi.Count();
                    if (bulunandosyaadeti>0)
                    {
                        string silinecek_klasor_yolu = dosya_dizisi[0].DirectoryName;
                        string[] klasor_dizisi = silinecek_klasor_yolu.Split('\\');
                        SILMEONAY:
                        Console.Write("{0} sınıfındaki {1} numaralı öğrenci kaydının silinmesini istiyor musunuz? (e=evet veya h=hayır)", klasor_dizisi[2], klasor_dizisi[3]);
                        string silme_onay = Console.ReadLine().ToUpper();
                        if (silme_onay=="E")
                        {
                            System.IO.Directory.Delete(silinecek_klasor_yolu, true);
                            Console.WriteLine("{0} sınıfındaki {1} numaralı öğrencinin kaydı silinmiştir.", klasor_dizisi[2], klasor_dizisi[3]);
                            goto BASADON;
                        }
                        else if (silme_onay=="H")
                        {
                            Console.Clear();
                            Console.WriteLine("Öğrenci kaydı silinmesinden vazgeçilmiştir.");
                            goto BASADON;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Yanlış menü seçimi yaptınız!");
                            goto SILMEONAY;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("{0} numaralı öğrenci kaydı yoktur.", ogrno);
                        goto BASADON;
                    }
                    break;

                case "4":
                    Console.Write("Öğrenci Numarasını giriniz?");
                    ogrno = Console.ReadLine();
                    System.IO.DirectoryInfo tasinacakklasorbilgisi = new System.IO.DirectoryInfo("c:\\Okul");
                    System.IO.FileInfo[] bulunandosyalar = tasinacakklasorbilgisi.GetFiles(ogrno + ".txt", System.IO.SearchOption.AllDirectories);
                    int dosyaadeti = bulunandosyalar.Count();
                    if (dosyaadeti>0)
                    {
                        string tasinacak_klasor_yolu = bulunandosyalar[0].DirectoryName;
                        string[] klasorler = tasinacak_klasor_yolu.Split('\\');
                        Console.WriteLine("{0} numaralı öğrenci hangi sınıfa taşınacaktır.[10-A,10-B,10-C]", klasorler[2]);
                        string tasinacak_klasoradi = Console.ReadLine();
                        if (System.IO.Directory.Exists(@"c:\\Okul"+"\\"+tasinacak_klasoradi)==true)
                        {
                            string hedef_klasor_yolu = @"c:\\Okul" + "\\" + tasinacak_klasoradi + "\\" + ogrno;
                            System.IO.Directory.Move(tasinacak_klasor_yolu, hedef_klasor_yolu);
                            Console.Clear();
                            Console.WriteLine("{0} sınıfındaki {1} numaralı öğrenci {2} sınıfına taşınmıştır.", klasorler[2], ogrno, tasinacak_klasoradi);
                            goto BASADON;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("{0} adında okulda sınıf yoktur.", tasinacak_klasoradi);
                            goto BASADON;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Okulda {0} numaralı öğrenci yoktur.", ogrno);
                        goto BASADON;
                    }
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Yanlış menü seçimi yaptınız?");
                    goto BASADON;
            }
        }
    }
}
