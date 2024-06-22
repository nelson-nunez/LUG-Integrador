1. Crear Modelo
2. Crear DB
3. Migrar a la db el modelo
4. Crear capas (Abst - BE - BLL - DAL - MPP - UI)
5. Crear clases
6. Crear conexion a db. Crear string en AppConfig de la UI (La mugre esta a veces lleva .\ o nada)
7. Crear Map del acceso
8. Crear Bll para probar conexion
9. Crear un front en la UI para llamar a las capas

Para los controles de usuarios recompilar para que aparezcan en el toolbox.

Hola Nelson,

Diagrama de clases: 
* Calefactor y Proveedor es una agregacion,
* Clase descuento no corresponde, es un metodo dento de las clases hijas.
* Cliente es una relacion con calefactor.
* No existen clases intermacia caliente calefactor, por eso cliente tiene una lista de calefactores...

all usar capa abstraccion faltaron las interfaces

CODIGO 6
CAPAS
BE
los metodos de polimo
public override decimal DescuentoCalculado()

BECliente no tiene que tener metodo Descuento calculado

no hace falta la clase class Constantes, podes usar enums.