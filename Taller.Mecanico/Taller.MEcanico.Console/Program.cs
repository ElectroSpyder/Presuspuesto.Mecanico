// See https://aka.ms/new-console-template for more information

using Taller.Mecanico.Logic.Implementacion;
using Taller.Mecanico.Persistence.UnitOfWork.Implementacion;

var unitOfWork = new UnitOfWork();

var servicio = new VehiculoService(unitOfWork);

var result = servicio.GetAll();



Console.WriteLine("Hello, World!");
