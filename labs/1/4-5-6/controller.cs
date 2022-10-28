
namespace RunProgram
{

    public static class Controller
    {

        public static SoftwareContainer FindGames(SoftwareContainer? cont, GameType type)
        {
            try
            {
                if (cont is null)
                    throw new ControllerException("null reference container");
                SoftwareContainer buff = new(new Game());
                for (int i = 0; i < cont.length; i++)
                {
                    if (cont[i] is Game elem && elem.Type == type)
                        buff.Add(cont[i]);
                }
                buff.Delete(0);
                return buff;
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine(e);
                return new SoftwareContainer(new Game());
            }
        }

        public static SoftwareContainer FindVersion(SoftwareContainer? cont, string version)
        {
            try
            {
                if (cont is null)
                    throw new ControllerException("null reference container");

                SoftwareContainer buff = new(new Game());
                for (int i = 0; i < cont.length; i++)
                {
                    if (cont[i] is Word && cont[i].Version == version)
                        buff.Add(cont[i]);
                }
                buff.Delete(0);
                return buff;
            }
            catch (Exception e)
            {
                if (e is OutOfMemoryException elem)
                {
                    Console.WriteLine(elem);
                    return new SoftwareContainer(new Game());
                }
                else throw;
            }
        }

        public static SoftwareContainer Sort(SoftwareContainer? cont)
        {
            try
            {
                if (cont is null)
                    throw new ControllerException("null reference container");
                cont.Sort();
                return cont;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

}