using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;
        public UsuarioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuario")]
        [Trait("CRUD", "UserEntity")]
        public async Task E_Possivel_Realizar_CRUD_Usuario()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repositorio = new UserImplementation(context);
                var emailTeste = Faker.Internet.Email();
                var nomeTeste = Faker.Name.FullName();
                UserEntity _entity = new UserEntity
                {
                    Email = emailTeste,
                    Name = nomeTeste
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);

                #region Insert
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);
                #endregion

                #region Update
                _entity.Name = Faker.Name.First();
                var registroAtualizado = await _repositorio.UpdateAsync(_entity);
                Assert.NotNull(registroAtualizado);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                #endregion

                #region Exists
                var registroExiste = await _repositorio.ExistAsync(registroAtualizado.Id);
                Assert.True(registroExiste);
                #endregion

                #region Select
                var registroSelecionado = await _repositorio.SelectAsync(registroAtualizado.Id);
                Assert.NotNull(registroSelecionado);
                Assert.Equal(registroAtualizado.Email, registroSelecionado.Email);
                Assert.Equal(registroAtualizado.Name, registroSelecionado.Name);
                #endregion

                #region Todos Registros
                var todosRegistros = await _repositorio.SelectAsync();
                Assert.NotNull(todosRegistros);
                Assert.True(todosRegistros.Count() > 0);
                #endregion

                #region Delete
                var removeu = await _repositorio.DeleteAsync(registroSelecionado.Id);
                Assert.True(removeu);
                #endregion

                #region Get by Email
                var usuarioPadrao = await _repositorio.findByLogin("emailAdmin@email.com");
                Assert.NotNull(usuarioPadrao);
                Assert.Equal(usuarioPadrao.Email, "emailAdmin@email.com");
                Assert.Equal(usuarioPadrao.Name, "Admnistrador");
                #endregion
            }

        }
    }
}
