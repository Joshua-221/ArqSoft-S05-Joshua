# Diagrama de Arquitectura de CitasApp

```mermaid
classDiagram
    direction LR

    %% Controladores
    class PacientesController {
        -IPacienteService _pacienteService
    }
    class MedicosController {
        -IMedicoService _medicoService
    }
    class CitasController {
        -ICitaService _citaService
    }

    %% Servicios e Interfaces de Servicio
    class IPacienteService { <<interface>> }
    class PacienteService { }
    class IMedicoService { <<interface>> }
    class MedicoService { }
    class ICitaService { <<interface>> }
    class CitaService { }

    %% Repositorios e Interfaces de Datos
    class IPacienteRepository { <<interface>> }
    class RepositoryFactory {
        +CrearPacienteRepository()
    }
    class IMedicoRepository { <<interface>> }
    class JsonMedicoRepository { }
    class ICitaRepository { <<interface>> }
    class JsonCitaRepository { }

    %% Relaciones de Dependencia
    PacientesController --> IPacienteService
    MedicosController --> IMedicoService
    CitasController --> ICitaService

    PacienteService ..|> IPacienteService
    MedicoService ..|> IMedicoService
    CitaService ..|> ICitaService

    PacienteService --> IPacienteRepository
    MedicoService --> IMedicoRepository
    CitaService --> ICitaRepository

    %% Implementaciones de Repositorios
    RepositoryFactory ..> IPacienteRepository : Crea instancia con conLogging
    JsonMedicoRepository ..|> IMedicoRepository
    JsonCitaRepository ..|> ICitaRepository