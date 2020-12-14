-- MySQL Workbench Synchronization
-- Generated: 2020-12-12 12:51
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: Henrique

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

CREATE TABLE IF NOT EXISTS `bd_idrug`.`Farmacia` (
  `idFarmacia` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(60) NOT NULL,
  `cnpj` VARCHAR(14) NOT NULL,
  `telefone` VARCHAR(13) NOT NULL,
  `cep` VARCHAR(6) NOT NULL,
  `logradouro` VARCHAR(60) NOT NULL,
  `estado` VARCHAR(2) NOT NULL,
  `cidade` VARCHAR(25) NOT NULL,
  `bairro` VARCHAR(25) NOT NULL,
  `status` ENUM('ATIVA', 'INATIVA') NOT NULL DEFAULT 'INATIVA',
  PRIMARY KEY (`idFarmacia`),
  UNIQUE INDEX `idFarmacia_UNIQUE` (`idFarmacia` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `bd_idrug`.`Medicamento` (
  `idMedicamento` INT(11) NOT NULL AUTO_INCREMENT,
  `CategoriaMedicamento_idCategoriaMedicamento` INT(10) UNSIGNED NOT NULL,
  `codigoBarras` VARCHAR(20) NOT NULL,
  `nome` VARCHAR(60) NOT NULL,
  `fabricante` VARCHAR(40) NOT NULL,
  PRIMARY KEY (`idMedicamento`),
  UNIQUE INDEX `idMedicamento_UNIQUE` (`idMedicamento` ASC) VISIBLE,
  INDEX `fk_Medicamento_CategoriaMedicamento1_idx` (`CategoriaMedicamento_idCategoriaMedicamento` ASC) VISIBLE,
  CONSTRAINT `idCategoriaMedicamento`
    FOREIGN KEY (`CategoriaMedicamento_idCategoriaMedicamento`)
    REFERENCES `bd_idrug`.`CategoriaMedicamento` (`idCategoriaMedicamento`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `bd_idrug`.`MedicamentoDisponivel` (
  `idDisponibilizacaoMedicamento` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `idFarmacia` INT(11) NOT NULL,
  `idMedicamento` INT(11) NOT NULL,
  `dataInicioDisponibilizacao` DATETIME NOT NULL,
  `dataFimDisponibilizacao` DATETIME NOT NULL,
  `quantidadeDisponibilizacao` INT(11) NOT NULL,
  `lote` VARCHAR(45) NOT NULL,
  `quantidade` VARCHAR(45) NOT NULL,
  `validadeMes` DATETIME NOT NULL,
  `validadeAno` VARCHAR(45) NOT NULL,
  `statusMedicamento` ENUM('RESERVADO', 'DISPONIVEL', 'INDISPONIVEL') NOT NULL DEFAULT 'DISPONIVEL',
  `dataVencimento` DATETIME NOT NULL,
  `quantidadeReservada` INT(11) NOT NULL,
  `quantidadeEntregue` INT(11) NOT NULL,
  `quantidadeDisponivel` INT(11) NOT NULL,
  `imagem` BLOB NULL DEFAULT NULL,
  PRIMARY KEY (`idDisponibilizacaoMedicamento`),
  INDEX `fk_TB_FARMACIA_has_TB_MEDICAMENTO_TB_MEDICAMENTO1_idx` (`idMedicamento` ASC) VISIBLE,
  INDEX `fk_TB_FARMACIA_has_TB_MEDICAMENTO_TB_FARMACIA_idx` (`idFarmacia` ASC) VISIBLE,
  UNIQUE INDEX `idDisponibilizacaoMedicamento_UNIQUE` (`idDisponibilizacaoMedicamento` ASC) VISIBLE,
  CONSTRAINT `idFarmacia`
    FOREIGN KEY (`idFarmacia`)
    REFERENCES `bd_idrug`.`Farmacia` (`idFarmacia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `idMedicamento`
    FOREIGN KEY (`idMedicamento`)
    REFERENCES `bd_idrug`.`Medicamento` (`idMedicamento`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `bd_idrug`.`CategoriaMedicamento` (
  `idCategoriaMedicamento` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `nomeCategoria` VARCHAR(60) NOT NULL,
  PRIMARY KEY (`idCategoriaMedicamento`),
  UNIQUE INDEX `idCategoriaMedicamento_UNIQUE` (`idCategoriaMedicamento` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `bd_idrug`.`Usuario` (
  `idUsuario` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `idFarmacia` INT(10) UNSIGNED NOT NULL,
  `tipoUsuario` ENUM('ADMINISTRADOR', 'FARMACEUTICO', 'SOLICITANTE') NOT NULL DEFAULT 'SOLICITANTE',
  `nome` VARCHAR(45) NOT NULL,
  `cpf` VARCHAR(12) NOT NULL,
  `telefone` VARCHAR(13) NULL DEFAULT NULL,
  `sexo` VARCHAR(1) NOT NULL,
  `logradouro` VARCHAR(60) NOT NULL,
  `estado` VARCHAR(2) NOT NULL,
  `cidade` VARCHAR(25) NOT NULL,
  `bairro` VARCHAR(25) NOT NULL,
  `email` VARCHAR(30) NOT NULL,
  `senha` VARCHAR(12) NOT NULL,
  PRIMARY KEY (`idUsuario`),
  INDEX `fk_TB_USUARIO_TB_FARMACIA1_idx` (`idFarmacia` ASC) INVISIBLE,
  UNIQUE INDEX `idUsuario_UNIQUE` (`idUsuario` ASC) VISIBLE,
  CONSTRAINT `idFarmacia`
    FOREIGN KEY (`idFarmacia`)
    REFERENCES `bd_idrug`.`Farmacia` (`idFarmacia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `bd_idrug`.`SolicitacaoMedicamento` (
  `idSolicitacaoMedicamento` INT(11) NOT NULL AUTO_INCREMENT,
  `idDisponibilizacaoMedicamento` INT(10) UNSIGNED NOT NULL,
  `idUsuario` INT(10) UNSIGNED NOT NULL,
  `quantidadeSolicitada` INT(11) NOT NULL,
  `statusSolicitacaoMedicamento` ENUM('CONCLUIDA', 'EM ANDAMENTO', 'CANCELADA') NOT NULL DEFAULT 'EM ANDAMENTO',
  `quantidadeEntregue` INT(11) NOT NULL,
  `prazoEntrega` DATETIME NOT NULL,
  `dataSolicitacao` DATETIME NOT NULL,
  `dataEntrega` DATETIME NOT NULL,
  `cpf` VARCHAR(12) NOT NULL,
  INDEX `fk_tbDisponibilizaMedicamento_has_tbUsuario_tbUsuario1_idx` (`idUsuario` ASC) VISIBLE,
  INDEX `fk_tbDisponibilizaMedicamento_has_tbUsuario_tbDisponibiliza_idx` (`idDisponibilizacaoMedicamento` ASC) VISIBLE,
  PRIMARY KEY (`idSolicitacaoMedicamento`),
  UNIQUE INDEX `idSolicitacaoMedicamento_UNIQUE` (`idSolicitacaoMedicamento` ASC) VISIBLE,
  CONSTRAINT `idDisponibilizacaoMedicamento`
    FOREIGN KEY (`idDisponibilizacaoMedicamento`)
    REFERENCES `bd_idrug`.`MedicamentoDisponivel` (`idDisponibilizacaoMedicamento`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `idUsuario`
    FOREIGN KEY (`idUsuario`)
    REFERENCES `bd_idrug`.`Usuario` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
