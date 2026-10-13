# Информационная система учёта заявок сервисного центра

Курсовая работа: веб-API для учёта заявок на обслуживание техники.

Система регистрирует заявку (клиент, описание неисправности, приоритет), хранит её и позволяет менять статус: принята, в работе, выполнена, отменена. Стек: Python, FastAPI, PostgreSQL, Swagger (OpenAPI).

## Запуск

```bash
python -m venv .venv
source .venv/bin/activate
pip install -r requirements.txt
uvicorn service_requests.main:app --reload
```

Страница Swagger: `http://127.0.0.1:8000/docs`.

Проверка стиля и тесты:

```bash
ruff check .
pytest
```
