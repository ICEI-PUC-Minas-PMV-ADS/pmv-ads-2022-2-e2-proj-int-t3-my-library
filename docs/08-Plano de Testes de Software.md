# Plano de Testes de Software

Os requisitos para realização dos testes de software são:
Site publicado na Internet
Navegador da Internet - Chrome, Firefox ou Edge
Conectividade de Internet para acesso às plataformas (API’s)
Aplicativos de teste unitários em API’s
Elaboração de códigos para testes no banco de dados

Os testes funcionais a serem realizados no aplicativo são descritos a seguir.


Caso de Teste
CT-01 - Teste de unidade
Objetivo do Teste
Encontrar falhas em funcionalidades independentes
Requisitos Associados
RF-1 - O sistema deve ter uma tela inicial para realização de
login.
RF-2 - O sistema deve ter na tela inicial opção para
cadastramento.
RF-3 - O sistema deve possuir um menu lateral interativo para
que o usuário navegue nas funcionalidades: Bibliotecas,
Minha Biblioteca, Livros Emprestados, Meus
Empréstimos, Reservas.
RF-4 - O sistema deverá possuir uma sessão de bibliotecas, onde
o usuário visualiza livros de outras bibliotecas e fará
reservas e empréstimo.
RF-5 - Deve ter na tela das Bibliotecas: campo para busca,
listagem dos livros com opção para realizar reservas e
fazer empréstimo.
RF-6 - O sistema deverá possuir uma sessão de minha biblioteca,
onde o usuário conseguirá cadastrar seus livros, editar ou
removê-los.
RF-7 - Deve ter na tela Minha Biblioteca: campo para busca,
campo do nome da biblioteca, listagem dos livros com
opção para: cadastro, edição e remoção.
RF-8 - O sistema deverá possuir uma sessão de meus
empréstimos onde o usuário controlará os livros que ele
pegou emprestado com outros usuários.
RF-9 - Deve ter na tela Meus Empréstimos: campo para busca,
informar a devolução e solicitar adiamento.
RF-10 - O sistema deverá possuir uma sessão de livros
emprestados onde o usuário controlará os livros que ele
emprestou a outros usuários.
RF-11 - Deve ter na tela Livros Emprestados: campo para busca,
solicitar devolução, alterar data de devolução.
RF-12 - Deve ter na tela Reservas, a listagem das Minhas Reservas
e Solicitações de Reservas.
RF-13 - Deve ter na tela Reservas, a listagem das Minhas Reservas
e Solicitações de Reservas.
RF-14 - Deve ter na tela Minhas Reservas: cancelar reserva.
RF-15 - O sistema deverá possuir uma sessão de solicitações de
reservas, onde o usuário visualiza reservas solicitadas por
outros usuários.
RF-16 - Deve ter na tela Solicitações de Reservas: aprovar reserva.
RF-17 - Deve ter tela para atualização cadastral.
Como é o Teste
O teste unitário consiste em elaborar métodos que testam as funcionalidades isoladas do sistema.
Ferramentas Necessárias
Será usado as seguintes ferramentas: Insomnia e Postman.
Critérios de Êxito
O teste terá sucesso se o sistema tratar corretamente todas as possibilidades de entradas de dados e opções utilizadas.




Caso de Teste
CT-02 - Teste de sistema
Objetivo do Teste
Executar o sistema sob ponto de vista de seu usuário final, varrendo as funcionalidades em busca de falhas.
Requisitos Associados
RF-1 - O sistema deve ter uma tela inicial para realização de
login.
RF-2 - O sistema deve ter na tela inicial opção para
cadastramento.
RF-3 - O sistema deve possuir um menu lateral interativo para
que o usuário navegue nas funcionalidades: Bibliotecas,
Minha Biblioteca, Livros Emprestados, Meus
Empréstimos, Reservas.
RF-4 - O sistema deverá possuir uma sessão de bibliotecas, onde
o usuário visualiza livros de outras bibliotecas e fará
reservas e empréstimo.
RF-5 - Deve ter na tela das Bibliotecas: campo para busca,
listagem dos livros com opção para realizar reservas e
fazer empréstimo.
RF-6 - O sistema deverá possuir uma sessão de minha biblioteca,
onde o usuário conseguirá cadastrar seus livros, editar ou
removê-los.
RF-7 - Deve ter na tela Minha Biblioteca: campo para busca,
campo do nome da biblioteca, listagem dos livros com
opção para: cadastro, edição e remoção.
RF-8 - O sistema deverá possuir uma sessão de meus
empréstimos onde o usuário controlará os livros que ele
pegou emprestado com outros usuários.
RF-9 - Deve ter na tela Meus Empréstimos: campo para busca,
informar a devolução e solicitar adiamento.
RF-10 - O sistema deverá possuir uma sessão de livros
emprestados onde o usuário controlará os livros que ele
emprestou a outros usuários.
RF-11 - Deve ter na tela Livros Emprestados: campo para busca,
solicitar devolução, alterar data de devolução.
RF-12 - Deve ter na tela Reservas, a listagem das Minhas Reservas
e Solicitações de Reservas.
RF-13 - Deve ter na tela Reservas, a listagem das Minhas Reservas
e Solicitações de Reservas.
RF-14 - Deve ter na tela Minhas Reservas: cancelar reserva.
RF-15 - O sistema deverá possuir uma sessão de solicitações de
reservas, onde o usuário visualiza reservas solicitadas por
outro usuários.
RF-16 - Deve ter na tela Solicitações de Reservas: aprovar reserva.
RF-17 - Deve ter tela para atualização cadastral.
Como é o Teste
Os testes serão executados em condições similares - de ambiente, interfaces sistêmicas e massas de dados - àquelas que um usuário utilizará no seu dia-a-dia de manipulação do sistema. De acordo com a política de uma organização, podem ser utilizadas condições reais de ambiente, interfaces sistêmicas e massas de dados.
Ferramentas Necessárias
Nenhuma ferramenta especial necessária.
Critérios de Êxito
O sistema se comporta como esperado (de acordo com o documento de requisitos).


Caso de Teste
CT-03 - Teste de integridade de Dados e de Banco de dados
Objetivo do Teste
Experimentar processos e métodos de acesso a banco de dados independentes da UI para que você possa observar e registrar comportamentos-alvo incorretos ou a existência de dados corrompidos.
Requisitos Associados
RF-1 - O sistema deve ter uma tela inicial para realização de
login.
RF-2 - O sistema deve ter na tela inicial opção para
cadastramento.
RF-3 - O sistema deve possuir um menu lateral interativo para
que o usuário navegue nas funcionalidades: Bibliotecas,
Minha Biblioteca, Livros Emprestados, Meus
Empréstimos, Reservas.
RF-4 - O sistema deverá possuir uma sessão de bibliotecas, onde
o usuário visualiza livros de outras bibliotecas e fará
reservas e empréstimo.
RF-5 - Deve ter na tela das Bibliotecas: campo para busca,
listagem dos livros com opção para realizar reservas e
fazer empréstimo.
RF-6 - O sistema deverá possuir uma sessão de minha biblioteca,
onde o usuário conseguirá cadastrar seus livros, editar ou
removê-los.
RF-7 - Deve ter na tela Minha Biblioteca: campo para busca,
campo do nome da biblioteca, listagem dos livros com
opção para: cadastro, edição e remoção.
RF-8 - O sistema deverá possuir uma sessão de meus
empréstimos onde o usuário controlará os livros que ele
pegou emprestado com outros usuários.
RF-9 - Deve ter na tela Meus Empréstimos: campo para busca,
informar a devolução e solicitar adiamento.
RF-10 - O sistema deverá possuir uma sessão de livros
emprestados onde o usuário controlará os livros que ele
emprestou a outros usuários.
RF-11 - Deve ter na tela Livros Emprestados: campo para busca,
solicitar devolução, alterar data de devolução.
RF-12 - Deve ter na tela Reservas, a listagem das Minhas Reservas
e Solicitações de Reservas.
RF-13 - Deve ter na tela Reservas, a listagem das Minhas Reservas
e Solicitações de Reservas.
RF-14 - Deve ter na tela Minhas Reservas: cancelar reserva.
RF-15 - O sistema deverá possuir uma sessão de solicitações de
reservas, onde o usuário visualiza reservas solicitadas por
outros usuários.
RF-16 - Deve ter na tela Solicitações de Reservas: aprovar reserva.
RF-17 - Deve ter tela para atualização cadastral.
Como é o Teste
Dispare cada processo e método de acesso a banco de dados, propagando dados válidos e inválidos ou solicitações de dados em cada um deles.
Inspecione o banco de dados para assegurar que os dados foram distribuídos conforme o planejado e que todos os eventos de banco retornados para assegurar que os dados corretos foram recuperados pelas razões corretas.
Ferramentas Necessárias
A técnica exige as seguintes ferramentas:
MySQL Client;
Banco de dados do sistema definido.
Critérios de Êxito
Ter o resultado esperado no banco de dados.


Caso de Teste
CT-04 - Teste de carga
Objetivo do Teste
Testar os casos de negócio em várias condições de carga de trabalho, a fim de observar e registrar o comportamento-alvo e os dados de desempenho do sistema.
Requisitos Associados
RF-1 - O sistema deve ter uma tela inicial para realização de
login.
RF-2 - O sistema deve ter na tela inicial opção para
cadastramento.
RF-3 - O sistema deve possuir um menu lateral interativo para
que o usuário navegue nas funcionalidades: Bibliotecas,
Minha Biblioteca, Livros Emprestados, Meus
Empréstimos, Reservas.
RF-4 - O sistema deverá possuir uma sessão de bibliotecas, onde
o usuário visualiza livros de outras bibliotecas e fará
reservas e empréstimo.
RF-5 - Deve ter na tela das Bibliotecas: campo para busca,
listagem dos livros com opção para realizar reservas e
fazer empréstimo.
RF-6 - O sistema deverá possuir uma sessão de minha biblioteca,
onde o usuário conseguirá cadastrar seus livros, editar ou
removê-los.
RF-7 - Deve ter na tela Minha Biblioteca: campo para busca,
campo do nome da biblioteca, listagem dos livros com
opção para: cadastro, edição e remoção.
RF-8 - O sistema deverá possuir uma sessão de meus
empréstimos onde o usuário controlará os livros que ele
pegou emprestado com outros usuários.
RF-9 - Deve ter na tela Meus Empréstimos: campo para busca,
informar a devolução e solicitar adiamento.
RF-10 - O sistema deverá possuir uma sessão de livros
emprestados onde o usuário controlará os livros que ele
emprestou a outros usuários.
RF-11 - Deve ter na tela Livros Emprestados: campo para busca,
solicitar devolução, alterar data de devolução.
RF-12 - Deve ter na tela Reservas, a listagem das Minhas Reservas
e Solicitações de Reservas.
RF-13 - Deve ter na tela Reservas, a listagem das Minhas Reservas
e Solicitações de Reservas.
RF-14 - Deve ter na tela Minhas Reservas: cancelar reserva.
RF-15 - O sistema deverá possuir uma sessão de solicitações de
reservas, onde o usuário visualiza reservas solicitadas por
outros usuários.
RF-16 - Deve ter na tela Solicitações de Reservas: aprovar reserva.
RF-17 - Deve ter tela para atualização cadastral.
Como é o Teste
Modifique os arquivos de dados a fim de aumentar o número de transações ou modifique os testes a fim de aumentar o número de vezes que cada transação ocorre.
As cargas de trabalho devem incluir cargas de pico - por exemplo, diárias, semanais e mensais.
As cargas de trabalho devem representar cargas médias assim como cargas de pico.
As cargas de trabalho devem representar picos instantâneos e picos sustentados.
As cargas de trabalho devem ser executadas com diferentes configurações do Ambiente de Teste.
Ferramentas Necessárias
A técnica exige as seguintes ferramentas:
Ferramenta de automação de scripts de teste;
Ferramenta de controle e de programação de carga de transações;
Ferramentas de monitoramento de instalação (registro, disco rígido CPU memória, etc);
Ferramentas de geração de dados.
Critérios de Êxito
O sistema suporta a carga de trabalho sem que nenhuma falha ocorra.



Caso de Teste
CT-05 - Teste de Segurança e de Controle de Acesso
Objetivo do Teste
Testar o sistema nas seguintes condições para observar e registrar o comportamento-alvo:
Segurança no nível do aplicativo: um ator poderá acessar somente as funções ou os dados para os quais seu tipo de usuário tenha recebido permissão;
Segurança no nível do sistema: somente os atores com acesso ao sistema e aos aplicativos têm permissão para acessá-los.
Requisitos Associados
RF-3 - O sistema deve possuir um menu lateral interativo para
que o usuário navegue nas funcionalidades: Bibliotecas,
Minha Biblioteca, Livros Emprestados, Meus
Empréstimos, Reservas.
RF-4 - O sistema deverá possuir uma sessão de bibliotecas, onde
o usuário visualiza livros de outras bibliotecas e fará
reservas e empréstimo.
RF-5 - Deve ter na tela das Bibliotecas: campo para busca,
listagem dos livros com opção para realizar reservas e
fazer empréstimo.
RF-6 - O sistema deverá possuir uma sessão de minha biblioteca,
onde o usuário conseguirá cadastrar seus livros, editar ou
removê-los.
RF-7 - Deve ter na tela Minha Biblioteca: campo para busca,
campo do nome da biblioteca, listagem dos livros com
opção para: cadastro, edição e remoção.
RF-8 - O sistema deverá possuir uma sessão de meus
empréstimos onde o usuário controlará os livros que ele
pegou emprestado com outros usuários.
RF-9 - Deve ter na tela Meus Empréstimos: campo para busca,
informar a devolução e solicitar adiamento.
RF-10 - O sistema deverá possuir uma sessão de livros
emprestados onde o usuário controlará os livros que ele
emprestou a outros usuários.
RF-11 - Deve ter na tela Livros Emprestados: campo para busca,
solicitar devolução, alterar data de devolução.
RF-12 - Deve ter na tela Reservas, a listagem das Minhas Reservas
e Solicitações de Reservas.
RF-13 - Deve ter na tela Reservas, a listagem das Minhas Reservas
e Solicitações de Reservas.
RF-14 - Deve ter na tela Minhas Reservas: cancelar reserva.
RF-15 - O sistema deverá possuir uma sessão de solicitações de
reservas, onde o usuário visualiza reservas solicitadas por
outros usuários.
RF-16 - Deve ter na tela Solicitações de Reservas: aprovar reserva.
RF-17 - Deve ter tela para atualização cadastral.
Como é o Teste
Segurança no nível do aplicativo: Identifique e liste cada tipo de usuário e as funções ou os dados para os quais cada tipo tem permissão de acesso.
Crie testes para cada tipo de usuário e verifique cada permissão criando transações específicas para cada tipo de usuário.
Modifique o tipo de usuário e execute novamente os testes para os mesmos usuários. Em cada caso, verifique se as funções ou dados adicionais estão corretamente disponíveis ou se têm seu acesso negado.
Acesso no nível do sistema: Consulte considerações especiais abaixo.
Ferramentas Necessárias
A técnica exige as seguintes ferramentas.
Ferramentas de investigação e contra a violação da segurança por “hackers”
Ferramentas de Administração da Segurança do Sistema Operacional.
O sistema operacional.
Critérios de Êxito
O sistema não foi comprometido durante os testes.




