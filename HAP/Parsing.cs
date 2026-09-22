namespace HAP
{
    public class Token //clase que creara los token que identifican que cosa es que
    {
        //Tipo de etiqueta texto, estructura etc
        public string? Tipo; // con ? se pone que acepte valores null
        public string? Valor; //valor que contiene la etiqueta

        public Token(string tipo, string valor) //constructor del objecto
        {
            Tipo = tipo;
            Valor = valor;
        }
    }

    public class CrearToken
    {

        public List<Token> tokens = new List<Token>();

        public void Detectar(string text)
        {
            string auxtext = "";
            string auxtextag = "";
            string tipo = "";
            string valor = "";
            foreach (char Char in text)
            {
                switch (Char)
                {
                    case '<':
                        auxtext = "";
                        if (Contiene(auxtext, Char))
                        {
                            return;
                        }
                        auxtext += Char;

                        break;

                    case '>':
                        auxtext += Char;
                        if (EtiquetaCorrecta(auxtext))
                        {
                            auxtextag += auxtext;
                            Token token = new Token("etiqueta", "prueba");
                            tokens.Add(token);
                            auxtext = "";
                        }
                        break;
                }
            }

            if (auxtext.Length > 0 && !auxtext.Contains('>'))
            {
                Console.WriteLine($"etiqueta no cerrada");
            }
        }

        public bool Contiene(string text, char Char)
        {
            if (text.Contains(Char))
            {
                Console.WriteLine($"Error de sintaxis");

                return true;
            }

            return false;
        }

        public bool EtiquetaCorrecta(string text)
        {
            bool EtiquetaInicio = false;
            bool EtiquetaCierre = false;
            foreach (char Char in text)
            {
                switch (Char)
                {
                    case '<':
                        if (!EtiquetaCierre)
                        {
                            EtiquetaInicio = true;
                        }
                        break;
                    case '>':
                        if (EtiquetaInicio)
                        {
                            EtiquetaCierre = true;
                        }

                        break;

                }
            }
            if (EtiquetaInicio && EtiquetaCierre)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Error de sintaxis");
                return false;
            }
        }


        public bool TipoEtiqueta(string text, ref string tipo, ref string valor)
        {
            text = text.Remove(0, 1);
            text = text.Remove(text.Length-1, 1);

            switch (text.ToLower())
            {
                case "p":
                return true;

                default:
                return false;
            }
            
        }

        public void MostrarTokens()
        {
            foreach (Token token in tokens)
            {
                Console.WriteLine($"Tipo: " + token.Tipo);
                Console.WriteLine($"Valor: " + token.Valor);
            }
        }

        public void LimpiaLista()
        {
            tokens.Clear();
        }
    }
}