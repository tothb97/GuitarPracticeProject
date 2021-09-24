# GuitarPracticeProject

-- Gitár hangoló és gyakorlást támogató program, 
a zenei hang spektrumának elemzésével

-- Az alkalmazás alapja a valós időben vagy felvételről 
megszólaltatott elektromos gitár hangmintájának elemzése és feldolgozása. Az 
applikációm az analizált hangmintából nyer ki információt és azt használja fel az 
alkalmazásban lévő funkciók működéséhez. Így a program képes a gitár húrjaiból 
keletkezett összetett rezgések spektrumát megvizsgálni és feldolgozni ezután az 
eredményül kapott adatokból meghatározza a gitáron játszott hangok zenei értelembe vett 
hangmagasságát.

-- Alkalmazott technológiál és eszközök:

- Fejlesztői környezet
A projektem fejlesztése Visual Studio 2017 fejlesztői környezetben, C# 
programozási nyelven készült. Az alkalmazás Windows Forms (.NET Framework) 
felhasználói felületen jelenik meg.

- NAudio, audio library
NAudio egy nyílt forráskódú .NET könyvtár, amit az applikációm használ. Maga a 
könyvtár audio-val kapcsolatos osztályokat tartalmaz, amik .NET-es környezetben 
nyújthat segítséget a felhasználójának és csökkentheti a programhoz szükséges fejlesztési 
időt . Ezt az eszközt elsősorban digitális audio feldolgozáshoz használtam. Mivel az 
alkalmazásom fő eleme a hang analizálás így a különböző funkciók hátterét ez a könyvtár 
biztosítja.

- Audacity digitális audió-szerkesztő
Az Audacity egy nyílt forráskódú digitális audio-szerkesztő program számos 
rendeltetéssel. A programot a hangsávok és frekvencia spektrumok vizuális 
reprezentálására használtam.

- Hangszer és erősítő
A programomon való tesztelést két különböző elektromos gitárral végeztem. A 
hangszerem hangja egy hang modellező gitár erősítőn keresztül kapcsolódik a 
számítógépembe USB interfészként keresztűl
