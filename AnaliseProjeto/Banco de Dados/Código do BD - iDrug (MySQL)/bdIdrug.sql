-- MySQL Workbench Synchronization
-- Generated: 2020-11-23 10:15
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: Henrique

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

CREATE TABLE IF NOT EXISTS `bd_idrug`.`tbFarmacia` (
  `idFarmacia` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `nomeFarmacia` VARCHAR(60) NOT NULL,
  `cnpj` VARCHAR(14) NOT NULL,
  `telefone` VARCHAR(13) NOT NULL,
  `cep` VARCHAR(6) NOT NULL,
  `logradouro` VARCHAR(60) NOT NULL,
  `estado` VARCHAR(2) NOT NULL,
  `cidade` VARCHAR(25) NOT NULL,
  `bairro` VARCHAR(25) NOT NULL,
  `email` VARCHAR(30) NOT NULL,
  `senha` VARCHAR(12) NOT NULL,
  PRIMARY KEY (`idFarmacia`),
  UNIQUE INDEX `idFarmacia_UNIQUE` (`idFarmacia` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `bd_idrug`.`tbMedicamento` (
  `idMedicamento` INT(11) NOT NULL AUTO_INCREMENT,
  `codBarras` VARCHAR(20) NOT NULL,
  `nomeMedicamento` VARCHAR(60) NOT NULL,
  `fabricante` VARCHAR(40) NOT NULL,
  `qtde` INT(11) NOT NULL,
  `lote` VARCHAR(25) NOT NULL,
  `valMes` DATETIME NOT NULL,
  `valAno` DATETIME NOT NULL,
  PRIMARY KEY (`idMedicamento`),
  UNIQUE INDEX `idMedicamento_UNIQUE` (`idMedicamento` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `bd_idrug`.`tbDisponibilizaMedicamento` (
  `idDisponibilizacaoMedicamento` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `idFarmacia` INT(11) NOT NULL,
  `idMedicamento` INT(11) NOT NULL,
  `dataInicio` INT(11) NOT NULL,
  `dataFim` DATETIME NOT NULL,
  `qtde` INT(11) NOT NULL,
  PRIMARY KEY (`idDisponibilizacaoMedicamento`),
  INDEX `fk_TB_FARMACIA_has_TB_MEDICAMENTO_TB_MEDICAMENTO1_idx` (`idMedicamento` ASC) VISIBLE,
  INDEX `fk_TB_FARMACIA_has_TB_MEDICAMENTO_TB_FARMACIA_idx` (`idFarmacia` ASC) VISIBLE,
  UNIQUE INDEX `idDisponibilizacaoMedicamento_UNIQUE` (`idDisponibilizacaoMedicamento` ASC) VISIBLE,
  CONSTRAINT `idFarmacia`
    FOREIGN KEY (`idFarmacia`)
    REFERENCES `bd_idrug`.`tbFarmacia` (`idFarmacia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `idMedicamento`
    FOREIGN KEY (`idMedicamento`)
    REFERENCES `bd_idrug`.`tbMedicamento` (`idMedicamento`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `bd_idrug`.`tbCategoriaMedicamento` (
  `idCategoriaMedicamento` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `nomeCategoria` VARCHAR(60) NOT NULL,
  PRIMARY KEY (`idCategoriaMedicamento`),
  UNIQUE INDEX `idCategoriaMedicamento_UNIQUE` (`idCategoriaMedicamento` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `bd_idrug`.`tbRelacionaMedicamentoCategoria` (
  `idMedicamento` INT(11) NOT NULL,
  `idCategoriaMedicamento` INT(10) UNSIGNED NOT NULL,
  PRIMARY KEY (`idMedicamento`, `idCategoriaMedicamento`),
  INDEX `fk_TB_MEDICAMENTO_has_TB_CATEGORIA_MEDICAMENTO_TB_CATEGORIA_idx` (`idCategoriaMedicamento` ASC) VISIBLE,
  INDEX `fk_TB_MEDICAMENTO_has_TB_CATEGORIA_MEDICAMENTO_TB_MEDICAMEN_idx` (`idMedicamento` ASC) VISIBLE,
  CONSTRAINT `idMedicamento`
    FOREIGN KEY (`idMedicamento`)
    REFERENCES `bd_idrug`.`tbMedicamento` (`idMedicamento`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `idCategoriaMedicamento`
    FOREIGN KEY (`idCategoriaMedicamento`)
    REFERENCES `bd_idrug`.`tbCategoriaMedicamento` (`idCategoriaMedicamento`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `bd_idrug`.`tbUsuario` (
  `idUsuario` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `idFarmacia` INT(10) UNSIGNED NOT NULL,
  `tipoUsuario` VARCHAR(15) NOT NULL,
  `nome` VARCHAR(45) NOT NULL,
  `sobrenome` VARCHAR(45) NULL DEFAULT NULL,
  `cpf` VARCHAR(12) NOT NULL,
  `telefone` VARCHAR(13) NULL DEFAULT NULL,
  `email` VARCHAR(30) NOT NULL,
  `senha` VARCHAR(12) NOT NULL,
  `sexo` VARCHAR(1) NOT NULL,
  `logradouro` VARCHAR(60) NOT NULL,
  `estado` VARCHAR(2) NOT NULL,
  `cidade` VARCHAR(25) NOT NULL,
  `bairro` VARCHAR(25) NOT NULL,
  PRIMARY KEY (`idUsuario`),
  INDEX `fk_TB_USUARIO_TB_FARMACIA1_idx` (`idFarmacia` ASC) INVISIBLE,
  UNIQUE INDEX `idUsuario_UNIQUE` (`idUsuario` ASC) VISIBLE,
  CONSTRAINT `idFarmacia`
    FOREIGN KEY (`idFarmacia`)
    REFERENCES `bd_idrug`.`tbFarmacia` (`idFarmacia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `bd_idrug`.`tbSolicitacaoMedicamento` (
  `idSolicitacaoMedicamento` INT(11) NOT NULL AUTO_INCREMENT,
  `idDisponibilizacaoMedicamento` INT(10) UNSIGNED NOT NULL,
  `idUsuario` INT(10) UNSIGNED NOT NULL,
  `qtdeSolicitada` INT(11) NOT NULL,
  `qtdeEntregue` INT(11) NOT NULL,
  `status` TINYINT(4) NOT NULL,
  INDEX `fk_tbDisponibilizaMedicamento_has_tbUsuario_tbUsuario1_idx` (`idUsuario` ASC) VISIBLE,
  INDEX `fk_tbDisponibilizaMedicamento_has_tbUsuario_tbDisponibiliza_idx` (`idDisponibilizacaoMedicamento` ASC) VISIBLE,
  PRIMARY KEY (`idSolicitacaoMedicamento`),
  UNIQUE INDEX `idSolicitacaoMedicamento_UNIQUE` (`idSolicitacaoMedicamento` ASC) VISIBLE,
  CONSTRAINT `idDisponibilizacaoMedicamento`
    FOREIGN KEY (`idDisponibilizacaoMedicamento`)
    REFERENCES `bd_idrug`.`tbDisponibilizaMedicamento` (`idDisponibilizacaoMedicamento`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `idUsuario`
    FOREIGN KEY (`idUsuario`)
    REFERENCES `bd_idrug`.`tbUsuario` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

DROP TABLE IF EXISTS `bd_idrug`.`tb_medicamento` ;

DROP TABLE IF EXISTS `bd_idrug`.`tb_farmacia` ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
