namespace MusicVault.Backend.Model.Recenzija;

public abstract class StanjeRecenzije {
    public Recenzija Recenzija { get; set; }

    public virtual void Preuzimanje() { }
    public virtual void Oduzimanje(Korisnik novUrendik) { }
    public virtual void Prihvatanje() { }
    public virtual void Odbijanje() { }
    public virtual void SlanjeNaOveru() { }
    public virtual void Arhiviranje() { }
    public virtual void Vracanje() { }
    public virtual void ObjavaSadrzaja() { }

    public StanjeRecenzije(Recenzija recenzija) {
        Recenzija = recenzija;
    }
}

public class Rezervisano : StanjeRecenzije {
    public Rezervisano(Recenzija recenzija) : base(recenzija) { }
    public override void Preuzimanje() { }
}

public class NaIzradi : StanjeRecenzije {
    public NaIzradi(Recenzija recenzija) : base(recenzija) { }
    public override void SlanjeNaOveru() {
        // 1. salji adminu poruku da se recenzija salje na overu - preko funkcije iz recenzije
        // 2. stavi da je aktuelno stanje recenzije na overi
        Recenzija.SlanjeMaila("admin@todo.com", "Recenzija sa ID-jem " + Recenzija.Id + " se salje na overu.");
        Recenzija.PromeniStanje(Stanje.NaOveri);
    }

    public override void Oduzimanje(Korisnik novUrednik) {
        // 1. trenutnom uredniku recenzije se salje mail da je oduzeta recenzija - preko funkcije iz recenzije
        // 2. novom uredniku se salje mail da je dobio - preko funkcije iz recenzije
        // 3. nov urednik (novUrendik) postaje urednik trenutne recenzije
        Recenzija.SlanjeMaila("urednik@todo.com", "Recenzija sa ID-jem " + Recenzija.Id + " vam je oduzeta.");
        Recenzija.SlanjeMaila("urednik@todo.com", "Recenzija sa ID-jem " + Recenzija.Id + " vam je dodeljena.");
        Recenzija.AzurirajUrednika(novUrednik);
    }
}

public class Arhivirano : StanjeRecenzije {
    public Arhivirano(Recenzija recenzija) : base(recenzija) { }
    public override void Vracanje() { }
}

public class Objavljeno : StanjeRecenzije {
    public Objavljeno(Recenzija recenzija) : base(recenzija) { }
    public override void Arhiviranje() { }
}

public class NaOveri : StanjeRecenzije {
    public NaOveri(Recenzija recenzija) : base(recenzija) { }
    public override void Oduzimanje(Korisnik novUrednik) {
        // 1. trenutnom uredniku recenzije se salje mail da je oduzeta recenzija - preko funkcije iz recenzije
        // 2. novom uredniku se salje mail da je dobio - preko funkcije iz recenzije
        // 3. nov urednik (novUrendik) postaje urednik trenutne recenzije
        Recenzija.SlanjeMaila("urednik@todo.com", "Recenzija sa ID-jem " + Recenzija.Id + " vam je oduzeta.");
        Recenzija.SlanjeMaila("urednik@todo.com", "Recenzija sa ID-jem " + Recenzija.Id + " vam je dodeljena.");
        Recenzija.AzurirajUrednika(novUrednik);
        Recenzija.PromeniStanje(Stanje.NaIzradi);
    }

    public override void Odbijanje() {
        // 1. salje se mail trenutnom uredniku koje izmene treba da napravi - preko funkcije iz recenzije
        // 2. stanje se menja NaIzradi
        Recenzija.SlanjeMaila("urednik@todo.com", "Potrebno je namestiti te i te izmene za recenziju sa ID-jem " + Recenzija.Id);
        Recenzija.PromeniStanje(Stanje.NaIzradi);
    }

    public override void Prihvatanje() {
        // 1. posaljemo mail uredniku da je recenzija odobrena - preko funkcije iz recenzije
        // 2. promenim stanje na objavljeno
        // 3. poziva objavi od recenzije
        Recenzija.SlanjeMaila("urednik@todo.com", "Recenzija sa ID-jem " + Recenzija.Id + " je odobrena");
        Recenzija.Objavi();
        Recenzija.PromeniStanje(Stanje.Objavljeno);
    }
}