using Fantasy.Frontend.Repositories;
using Fantasy.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace Fantasy.Frontend.Pages.Contries
{
    //Codigo Blazor
    public partial class ContriesIndex
    {
        [Inject] private IRepository Repository { get; set; } = null!;//Inyectar Repositorio con Data Anotation para tener acceso al protocolo HTTP

        private List<Country>? Countries { get; set; }//Agregar Lista de Countries

        protected override async Task OnInitializedAsync()
        {
            var responseHttp = await Repository.GetAsync<List<Country>>("api/countries");
            Countries = responseHttp.Response;
        }
    }
}