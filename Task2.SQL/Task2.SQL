create table dbo.products(
  id integer not null,
  name varchar(255) null,

  constraint pk_products_id primary key (id)
);

create table dbo.categories(
  id integer not null,
  name varchar(255) null,

  constraint pk_categories_id primary key (id)
);

create table dbo.products_categories(
  product_id integer not null,
  category_id integer not null,

  constraint fk_products_categories_product_id foreign key (product_id) references dbo.products(id),
  constraint fk_products_categories_category_id foreign key (category_id) references dbo.categories(id)
);

insert into dbo.categories (id, name) values (1,'Инструменты');
insert into dbo.categories (id, name) values (2,'Одежда');
insert into dbo.categories (id, name) values (3,'Продукты');

insert into dbo.products (id, name) values (1,'Молоток');
insert into dbo.products (id, name) values (2,'отвертка');
insert into dbo.products (id, name) values (3,'Пила');
insert into dbo.products (id, name) values (4,'Футболка');
insert into dbo.products (id, name) values (5,'Рубашка');
insert into dbo.products (id, name) values (6,'Пальто');
insert into dbo.products (id, name) values (7,'Филе');
insert into dbo.products (id, name) values (8,'Колбаса');
insert into dbo.products (id, name) values (9,'Хлеб');
insert into dbo.products (id, name) values (10,'Строительные ботинки');
insert into dbo.products (id, name) values (11,'Сыр');
insert into dbo.products (id, name) values (12,'Масло');
insert into dbo.products (id, name) values (13,'Товар без категории');

insert into dbo.products_categories(product_id, category_id) values (1,1);
insert into dbo.products_categories(product_id, category_id) values (2,1);
insert into dbo.products_categories(product_id, category_id) values (3,1);
insert into dbo.products_categories(product_id, category_id) values (4,2);
insert into dbo.products_categories(product_id, category_id) values (5,2);
insert into dbo.products_categories(product_id, category_id) values (6,2);
insert into dbo.products_categories(product_id, category_id) values (7,3);
insert into dbo.products_categories(product_id, category_id) values (8,3);
insert into dbo.products_categories(product_id, category_id) values (9,3);
insert into dbo.products_categories(product_id, category_id) values (10,2);
insert into dbo.products_categories(product_id, category_id) values (10,3);
insert into dbo.products_categories(product_id, category_id) values (11,1);
insert into dbo.products_categories(product_id, category_id) values (11,2);
insert into dbo.products_categories(product_id, category_id) values (11,2);

select concat(query.product, ' - ', isnull(query.category, 'Без категории'))
from
	(select p.name as product, c.name as category
	from dbo.products p
	left join dbo.products_categories pm on p.id = pm.product_id
	left join dbo.categories c on pm.category_id = c.id) as query