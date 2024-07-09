using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using Teste_MVC_FranciscoBispo.Context;
using Teste_MVC_FranciscoBispo.Models;

namespace Teste_MVC_FranciscoBispo.Controllers;

public class ClienteController : Controller
{
    private readonly ApplicationDbContext db = new();

    // GET: Cliente
    public ActionResult Index(string pesquisaNome, string pesquisaDocumento)
    {
        var clientes = db.Clientes.Where(c => !c.IsDeleted);

        if (!String.IsNullOrEmpty(pesquisaNome))
        {
            clientes = clientes.Where(c => c.Nome.Contains(pesquisaNome));
        }

        if (!String.IsNullOrEmpty(pesquisaDocumento))
        {
            clientes = clientes.Where(c => c.Documento
                .Replace(".", string.Empty)
                .Replace("-", string.Empty)
            .Contains(pesquisaDocumento
                .Replace(".", string.Empty)
                .Replace("-", string.Empty)));
        }

        return View(clientes.ToList());
    }

    // GET: Cliente/Details/5
    public ActionResult Details(int? id)
    {
        Cliente cliente = db.Clientes.Find(id);
        return View(cliente);
    }

    // GET: Cliente/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Cliente/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Cliente cliente)
    {
        if (ModelState.IsValid)
        {
            cliente.DataCadastro = DateTime.Now;
            db.Clientes.Add(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(cliente);
    }

    // GET: Cliente/Edit/5
    public ActionResult Edit(int id)
    {
        Cliente customer = db.Clientes.Find(id);
        return View(customer);
    }

    // POST: Cliente/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Cliente cliente)
    {
        if (ModelState.IsValid)
        {
            db.Entry(cliente).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(cliente);
    }

    // GET: Cliente/Delete/5
    public ActionResult Delete(int? id)
    {
        Cliente cliente = db.Clientes.Find(id);
        return View(cliente);
    }

    // POST: Cliente/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Cliente cliente = db.Clientes.Find(id);
        cliente.IsDeleted = true;
        db.Entry(cliente).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
}