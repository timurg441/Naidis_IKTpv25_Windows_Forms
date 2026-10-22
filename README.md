# Naidis_IKTpv25_Windows_Forms

# Kolm rakendust (Windows Forms)

## Projekti nimi, eesmärk ja kirjeldus

Nimi: Kolm rakendust (Windows Forms)

Eesmärk: Õppida tegema Windows Forms rakendusi ainult koodiga (ilma Toolboxita) ja kasutada objektorienteeritud programmeerimise (OOP) põhimõtteid.

Kirjeldus: Projektis on avavorm (`Avavorm`), mille vasakul on puuvaade. Puust saab valida tavalisi juhtelemente (nupp, silt, märkeruut jne) või avada kolm rakendust:

1. Pildi vaatamise programm (`PictureViewerForm`) – valib failidialoogiga pildi, näitab seda, võimaldab muuta taustavärvi, venitada pilti ja pilti puhastada.
2. Matemaatiline äraarvamismäng (`MathQuizForm`) – 5 liitmisülesannet juhuslike arvudega, lõpus näidatakse punktid.
3. Sarnaste piltide leidmise mäng (`MatchingGameForm`) – 4x4 ruudustik, tuleb leida kõik sümbolite paarid.

Lisaks on klassid `Peavorm` ja `Alamvorm`, mis näitavad, kuidas vormi suurus ja värv antakse konstruktoris parameetritega.

## Kasutatud tehnoloogiad

- C#
- Windows Forms (.NET)
- Visual Studio

## Kuidas käivitada ja kasutada

1. Ava lahendus (`.sln`) Visual Studios.
2. Vajuta **F5** (või Start). Käivitub avavorm.
3. Vali vasakust puust:
   - Elemendid alt mõni element – see tuleb vormile, seda saab proovida;
   - Rakendused alt `Picture Viewer`, `Math Quiz` või `Matching Game` – avaneb vastav rakendus.
4. `Peavorm`i proovimiseks muuda failis `Program.cs` rida `Application.Run(new Avavorm());` kujule `Application.Run(new Peavorm());`.

Pildi vaatamine: vajuta „Näita pilti“ ja vali fail. „Stretch“ venitab pildi aknasse, „Määra taustavärv“ muudab tausta, „Puhasta pilt“ eemaldab pildi, „Sule“ sulgeb akna.

Matemaatiline mäng: sisesta vastus arvuväljale ja vajuta „Kontrolli“. Pärast 5 ülesannet näidatakse punktid.

Sarnaste piltide mäng: klõpsa kahele ruudule. Samad sümbolid jäävad nähtavale, erinevad peidetakse 0,75 s pärast. Mäng lõpeb, kui kõik paarid on leitud.

Edasiarendamise ideed

Pildi vaatamise programm
1. Nupud „Eelmine“ ja „Järgmine“ kausta piltide vaatamiseks.
2. Pildi salvestamine teise nime või vormingusse.
3. Slaidiseanss taimeriga.

**Matemaatiline äraarvamismäng**
1. Lisada lahutamine, korrutamine ja jagamine.
2. Ajapiirang igale ülesandele (taimer).
3. Raskusastme valik (väiksemad ja suuremad arvud) ning parimate tulemuste tabel.

Sarnaste piltide leidmise mäng
1. Käikude ja aja lugemine.
2. Raskusastme valik (4x4, 6x6).
3. Tavaliste piltide kasutamine sümbolite asemel.

Avavorm, Peavorm ja Alamvorm
1. Failiteed (pilt, `menu.xml`) panna suhteliseks, et programm töötaks igas arvutis.
2. Vana `MainMenu` asendada `MenuStrip`iga.
3. Alamvormile lisada rohkem parameetreid (nt tekst, fondi suurus).

## Eeldatav edasiareng

Esmalt parandada leitud vead: sarnaste piltide mängu sümbolite loend (`Z` ja `z` ei moodusta paari), absoluutsed failiteed ja puuduv veakontroll. Seejärel lisada ülaltoodud ideed ning teha projektist suurem programm, kus kõik rakendused avanevad ühest menüüst.
