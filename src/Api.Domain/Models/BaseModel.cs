using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Models
{

    /*
        Usamos a model quando queremos aplicar algum tipo de validação antes do objeto virar um tipo
        de entidade como por exemplo UserEntity.
        A model "geralmente" tem as propfull assim podendo gerar alguma validação antes de popular o atributo
    */
    public class BaseModel
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _createAt;
        public DateTime CreateAt
        {
            get { return _createAt; }
            set
            {
                _createAt = value == null ? DateTime.Now : value;
            }
        }

        private DateTime? _updateAt;
        public DateTime? UpdateAt
        {
            get { return _updateAt; }
            set { _updateAt = value; }
        }
    }
}
