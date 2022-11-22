# Jake stranky budou potreba pro system

##Role v systemu
    - Admin
    - Pecovatel
    - Veterinar
    - Dobrovolnik
    - Neregistrovany uzivatel

##Zodpovednosti kazde Role

###Admin
    - spravuje uživatele, jako jediný vytváří pečovatele a veterináře

###Pecovatel
    - spravuje zvířata, vede jejich evidenci
    - vytváří rozvrhy pro venčení
    - ověřuje dobrovolníky
    - schvaluje rezervace zvířat na venčení, eviduje zapůjčení a vrácení
    - vytváří požadavky na veterináře

###Veterinar
    - vyřizuje požadavky od pečovatele (plánuje vyšetření zvířat dle požadavků)
    - udržuje zdravotní záznamy zvířat

###Dobrovolnik
    - rezervuje zvířata na venčení
    - vidí historii svých venčení

###Neregistrovany uzivatel
    - prochází informace o útulku a zvířatech

##Stranky pro kazdou roli
Kazda role uvidi:
    - Login stranku. Bude moznost se bud prihlasit - pak probehne presmerovani
    podle toho jakou roli bude mit prihlaseny uzivatel. A nebo pokracovat bez prihlaseni.
    - Po prihlaseni kazdeho uzivatele se jako prvni zobrazi informace o
    prihlaseni.

###Admin
    - Po prihlaseni uvidi account info page
    - Vidi stranku pro zpravu uzivatelu. Tato stranka bude obsahovat tabulku pro kazdy
    typ role v systemu krome neprihlaseneho uzivatele. Mezi temito tabulkami bude mozne
    preklikavat a bude mozne je fitrovat, napr podle jmena, datumu pridani, etc.. Admin
    bude moct tyto uzivatele spravovat - tj. mazat, pridavat (menit, napr pecovatel -
    dobrovolnik)

###Pecovatel
    - Po login-page uvidi account info
    - dale vidi stranku s prehledem vsech zvirat v útulku, na teto strane vidi take
    tlacitko pro pridani, odebrani a editovani zvirete
    - vidi stranku s rozvrhem venčení, zde muze vytvaret, mazat a upravovat terminy venčení
      - to znamena ze schvali registraci venceni a pri zapujceni a vraceni tuto akci eviduje
    - vidi stranku, kde nove zaregistrovani uzivatele cekaji na overeni
    - vidi stranku se zviraty a jejich zdravotnimi zaznamy

###Veterinar
    - Po login-page uvidi account info
    - vidi stranku se zviraty a jejich zdravotnimi zaznamy

###Dobrovolnik
    - Po login-page uvidi account info
    - vidi stranku se zviraty a jejich zdravotnimi zaznamy
    - vidi stranku s historii vypujceni
    - vidi straku s rozvrhem venceni

###Neregistrovany uzivatel
    - po preskoceni login stranky vidi seznam vsech zvirat

##Seznam stranek na implementaci
 - login page
 - account details page
 - stranka se vsemi zviraty
 - stranka s detaily o útulku
 - stranka s vypujckami
 - stranka pro spravu uzivatelu
 - stranka s neverifikovanymi uzivateli (nutna?)
 - stranka s pending medical records
 - historie vypujceni bude na stejne strance jako account info?
