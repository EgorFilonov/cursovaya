"""Проверяет каркас API: список заявок, документ OpenAPI и страницу Swagger."""

from fastapi.testclient import TestClient

from service_requests.main import app

client = TestClient(app)


def test_list_requests_returns_demo_item() -> None:
    """GET /requests отдаёт демонстрационную заявку."""
    response = client.get("/requests")

    assert response.status_code == 200
    body = response.json()
    assert body[0]["client_name"] == "Иван Петров"
    assert body[0]["status"] == "принята"


def test_openapi_lists_requests() -> None:
    """Документ OpenAPI содержит операцию списка заявок."""
    response = client.get("/openapi.json")

    assert response.status_code == 200
    body = response.json()
    assert "/requests" in body["paths"]
    assert "Учёт заявок сервисного центра" in body["info"]["title"]


def test_swagger_ui_opens() -> None:
    """Страница Swagger UI открывается по адресу /docs."""
    response = client.get("/docs")

    assert response.status_code == 200
    assert "swagger" in response.text.lower()
