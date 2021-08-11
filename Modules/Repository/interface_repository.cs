using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Modules
{
    public interface interface_repository<v_name_class>
    {
        IList<v_name_class> List_Item();
        v_name_class Find(int id);
        void add(v_name_class obj);
        void delete(int id);
        void update(int id, v_name_class obj);
        List<v_name_class> Search(string word);

    }
}
