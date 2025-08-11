Exchange-Rate-BR
**Comparador de ofertas de remesas para clientes bancarios**

Este proyecto está diseñado para ayudar a los clientes bancarios a comparar ofertas de remesas utilizando diferentes APIs de tasas de cambio. 
La aplicación consulta varias fuentes de tasas de cambio y selecciona la mejor oferta disponible.

**Tecnologías utilizadas**
Lenguaje: C#
Framework: ASP.NET Core
Patrón de diseño: Repositorio

**Características principales:**

**AutoMapper:** Se utiliza para realizar un mapeo automático entre entidades y DTOs, lo que ayuda a optimizar el código y a evitar la duplicación en la lógica de conversión.

**Pruebas unitarias:** Estas pruebas abarcan los casos más importantes de la aplicación, garantizando la calidad y el correcto funcionamiento del código mediante herramientas como xUnit y Moq.

**Principios SOLID:** Se aplican en toda la arquitectura para asegurar que el sistema sea mantenible, escalable y flexible.

**Clases DTO:** Se emplean para estructurar y transportar datos entre las diferentes capas de manera clara y desacoplada.

**Código limpio, escalable y documentado:** Se sigue un enfoque de buenas prácticas y estándares de desarrollo, incluyendo comentarios y guías que facilitan la comprensión.

**ILogger: **Se integra un sistema de logging para rastrear el comportamiento del sistema y facilitar la depuración.

**Manejo de excepciones:** Se establece un sistema robusto para capturar, registrar y gestionar errores de manera controlada, evitando caídas inesperadas.

**DataAnnotations:** Se implementan validaciones directamente en las clases modelo para asegurar la integridad de los datos.

**Contenedor Docker:** Se configura para ejecutar la aplicación en entornos aislados y portables.

**JWT (JSON Web Tokens):** Se utiliza para garantizar una autenticación y autorización seguras en los endpoints protegidos.

**Endpoints disponibles**
POST /api/BestDeal/GetBestDeal
curl --location 'https://localhost:44309/api/BestDeal/GetBestDeal' \
--header 'accept: */*' \
--header 'Content-Type: application/json-patch+json' \
--data '{
    "sourceCurrency": "DOP",
    "targetCurrency": "USD",
    "amount": 10
}'

POST ​/api​/Login
curl --location 'https://localhost:44309/api/Login' \
--header 'accept: */*' \
--header 'Content-Type: application/json-patch+json' \
--data '{"nombreUsuario":"Gbatista","password":"3283BR2025"}'

The concept is to request several currency exchange rate APIs for remittance offers and
select the best deal.

Conditions:

• No UI expected.
• No SQL required.
• Must be unit-tested.
• Must work even if one or more APIs are unavailable or return invalid responses.
• Good practices expected (e.g., clean architecture, SOLID principles, logging, error
handling).

Process Input:

* one set of data {source currency, target currency, amount}
* Multiple API using the same data with different signatures

Process Output:

* All API respond with the same data in different formats
* Process must query, then select the highest conversion amount and return it in the least
amount of time

Sample APIs, each with its own url and credentials
API1 (JSON)
Input {from, to, value}
Output {rate}

API2 (XML)
Input <XML><From/><To/><Amount/></XML>
Output <XML><Result/></XML>

API3 (JSON)
Input{exchange: {sourceCurrency,targetCurrency, quantity}}
Output {statusCode, message, data: {total}}
