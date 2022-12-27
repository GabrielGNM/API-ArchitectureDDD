using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public UsuarioCrudCompleto(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }
        //Usado para realizar os testes, nesse caso para o cadastro do usuario.
        [Fact(DisplayName = "CRUD of Users")]
        [Trait("CRUD", "UserEntity")]
        public async Task IsUserCrudPossible()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repositorio = new UserImplementation(context);
                UserEntity _entity = new UserEntity
                {
                    Email = "teste@gmail.com",
                    Name = "teste"
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal("teste@gmail.com", _registroCriado.Email);
                Assert.Equal("teste", _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);
            }
        }
    }
}
