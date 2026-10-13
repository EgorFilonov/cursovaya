"""Точка входа веб-API учёта заявок сервисного центра."""

from enum import Enum

from fastapi import FastAPI
from pydantic import BaseModel, Field

from service_requests import __version__


class RequestStatus(str, Enum):
    """Статус заявки на обслуживание."""

    ACCEPTED = "принята"
    IN_PROGRESS = "в работе"
    DONE = "выполнена"
    CANCELLED = "отменена"


class ServiceRequest(BaseModel):
    """Заявка на обслуживание техники."""

    id: int = Field(examples=[1])
    client_name: str = Field(examples=["Иван Петров"])
    description: str = Field(examples=["Не включается ноутбук"])
    priority: int = Field(ge=1, le=3, examples=[2])
    status: RequestStatus


_REQUESTS: list[ServiceRequest] = [
    ServiceRequest(
        id=1,
        client_name="Иван Петров",
        description="Не включается ноутбук",
        priority=2,
        status=RequestStatus.ACCEPTED,
    )
]

app = FastAPI(
    title="Учёт заявок сервисного центра",
    version=__version__,
    description=(
        "Каркас API курсовой. Постоянное хранение в PostgreSQL появится отдельно, "
        "сейчас заявки лежат в памяти процесса."
    ),
)


@app.get("/requests")
def list_requests() -> list[ServiceRequest]:
    """Возвращает заявки, которые сейчас лежат в памяти процесса.

    Returns:
        Список заявок. Пока база не подключена, в нём одна демонстрационная запись.
    """
    return _REQUESTS
