using Jil;

namespace Genius.Models.Song
{
    public class Interactions
    {
        [JilDirective("cosign")]
        public bool Cosign { get; set; }

        [JilDirective("pyong")]
        public bool Pyong { get; set; }

        [JilDirective("vote")]
        public object Vote { get; set; }

        [JilDirective("following")]
        public bool Following { get; set; }
    }
}
