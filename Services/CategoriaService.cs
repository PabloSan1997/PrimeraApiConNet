using primeraapi.Models;

namespace primeraapi.services;
public class CategoriaService: ICategoriaService
{
    TareasContext context;
    public CategoriaService(TareasContext dbContext)
    {
        context = dbContext;
    }

    public IEnumerable<Categoria> Get()
    {
        return context.Categorias;
    }
    public async Task Save(Categoria categoria)
    {
        context.Add(categoria);
        await context.SaveChangesAsync();
    }
    public async Task Update(Guid id, Categoria categoria)
    {
        var categoriaActual = context.Categorias.Find(id);
        if (categoriaActual != null)
        {
            categoriaActual.Descripcion = categoria.Descripcion;
            categoriaActual.Peso = categoria.Peso;
            categoriaActual.Nombre = categoria.Nombre;
            await context.SaveChangesAsync();
        }
    }
    public async Task Delete(Guid id)
    {
        var categoriaActual = context.Categorias.Find(id);
        if (categoriaActual != null)
        {
            context.Categorias.Remove(categoriaActual);
            await context.SaveChangesAsync();
        }
    }
}

public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    Task Save(Categoria categoria);
    Task Update(Guid id, Categoria categoria);
    Task Delete(Guid id);
}